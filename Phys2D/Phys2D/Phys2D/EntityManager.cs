using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Phys2D
{
    public class EntityManager
    {
        public _2DMotionHandler m_motionHandler;
        public CollisionHandler m_collisionHandler;

        public List<Entity> m_entities;
        public Texture2D m_defCubetexture;

        public double floorY, screenRight, screenLeft=0.0;

        public static EntityManager m_instance=null;

        public static EntityManager GetInstance()
        {
            if (m_instance == null)
            {
                m_instance = new EntityManager();
            }
            return m_instance;
        }

        public static EntityManager GetInitInstance(ref Texture2D texture)
        {
            if (m_instance == null)
            {
                m_instance = new EntityManager(ref texture);
            }
            return m_instance;
        }
        
        private EntityManager()
        {
            Initialize();
        }

        private EntityManager(ref Texture2D texture)
        {
            m_defCubetexture = texture;
            Initialize();
            Vector2 pos, vel;
            pos = new Vector2(100.0f, 300.0f);
            vel = new Vector2(4.5f, -2.0f);
            AddEntity(new Entity(pos, vel));

            pos = new Vector2(500.0f, 300.0f);
            vel = new Vector2(-4.5f, -2.0f);
            AddEntity(new Entity(pos, vel));
        }

        public void Initialize()
        {
            m_entities = new List<Entity>(0);
            m_motionHandler = _2DMotionHandler.GetInstance();
            m_collisionHandler = CollisionHandler.GetInstance();
        }

        public void AddEntity(Entity e)
        {
            e.SetTexture(ref m_defCubetexture);
            //e.m_texture = m_defCubetexture;

            m_entities.Add(e);
            
        }

        public void Update(ref GameTime gameTime)
        {
            foreach(Entity entity in m_entities)
            {
                entity.Update(ref gameTime);
                if (entity.GetBotY() > floorY)
                {
                    entity.m_position.Y = (float)floorY - (float)entity.m_height;
                    entity.m_velocity = Physics.CalculateReboundForce(entity, new Vector2(0.0f, 1.0f));
                    entity.m_velocity *= (float)entity.m_coefFriction;
                }

                if (entity.GetLeftX() < screenLeft)
                    entity.m_velocity = Physics.CalculateReboundForce(entity, new Vector2(1.0f, 0.0f));
                else if (entity.GetRightX() > screenRight)
                    entity.m_velocity = Physics.CalculateReboundForce(entity, new Vector2(-1.0f, 0.0f));

                m_motionHandler.CalculateEulerMotion(gameTime.ElapsedGameTime.Milliseconds, entity);
            }
            m_collisionHandler.HandleAllCollisions(ref m_entities);
        }

        public void Draw(ref SpriteBatch sb)
        {
            Rectangle rect = new Rectangle();
            int width, height;
            foreach (Entity entity in m_entities)
            {
                width = m_defCubetexture.Width;
                height = m_defCubetexture.Height;
                rect.X = (int)entity.m_position.X;
                rect.Y = (int)entity.m_position.Y;
                rect.Width = width;
                rect.Height = height;
                sb.Draw(m_defCubetexture, rect, Color.White); 
            }
        }
    }
}
