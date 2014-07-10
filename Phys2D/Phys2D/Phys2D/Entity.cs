using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Phys2D
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Entity
    {
        public Vector2 m_position;
        public Vector2 m_velocity;
        public Vector2 m_angular_velocity;
        public Vector2 m_angular_momentum;
        public Vector2 m_orientation;
        public Vector2 m_impulseForce;
        public Vector2 m_force, m_zoneForces;
        public List<Vector2> m_vertexPoints;
        public Texture2D m_texture;
        public long m_id;
        public bool m_bPlayerControlled;
        public double m_width, m_height, m_mass, m_coefRestitution, m_coefFriction;

        public Entity()
        {
            DefaultInitialize();
        }

        public Entity(Vector2 pos, Vector2 vel)
        {
            m_bPlayerControlled = false;
            m_position= pos;
            m_velocity = vel;
            m_angular_velocity = Vector2.Zero;
            m_angular_momentum = Vector2.Zero;
            m_orientation = Vector2.Zero;
            m_force = Vector2.Zero;
            m_zoneForces = Vector2.Zero;
            m_vertexPoints = new List<Vector2>(0);
            m_width = 0;
            m_coefRestitution = 0.8;//1.0 for full bounce
            m_coefFriction = 1.0;//lower for higher froction
            m_height = 0;
            Random rand = new Random();
            m_mass = rand.Next(60, 100);
            m_texture = null;
            m_id = IDManager.GenerateNewID();
        }

        public void LoadTexture(ref ContentManager content)
        {
            m_texture = content.Load<Texture2D>("cube.png");
            m_width = m_texture.Width;
            m_height = m_texture.Height;
            GenerateVertexes();
        }

        public void SetTexture(ref Texture2D tex)
        {
            m_texture = tex;
            m_width = tex.Width;
            m_height = tex.Height;
        }

        public void DefaultInitialize()
        {
            m_bPlayerControlled = false;
            m_texture = new Texture2D(null, 0, 0);
            m_position = Vector2.Zero;
            m_velocity = Vector2.Zero;
            m_angular_velocity = Vector2.Zero;
            m_angular_momentum = Vector2.Zero;
            m_orientation = Vector2.Zero;
            m_force = Vector2.Zero;
            m_zoneForces = Vector2.Zero;
            m_width = 0;
            m_coefRestitution = 0.8;
            m_coefFriction = 1.0;
            m_height = 0;
            Random rand = new Random();
            m_mass = rand.Next(60, 100);
            m_vertexPoints = new List<Vector2>(0);
            m_id = IDManager.GenerateNewID();
        }

        public void GenerateVertexes()
        {
            /*
             *  X-----X
             *  |     |
             *  |     |
             *  X-----X
             *  
             * */
            m_vertexPoints.Clear();
            m_vertexPoints.Add(new Vector2((float)GetLeftX(), (float)GetTopY()));
            m_vertexPoints.Add(new Vector2((float)GetRightX(), (float)GetTopY()));
            m_vertexPoints.Add(new Vector2((float)GetRightX(), (float)GetBotY()));
            m_vertexPoints.Add(new Vector2((float)GetLeftX(), (float)GetBotY()));
        }

        public void Update(ref GameTime gameTime)
        {
           // m_position += m_velocity;
            //float delta = gameTime.ElapsedGameTime.Milliseconds / 1000.0f;
           
            //m_force = Vector2.Zero;
            //m_force += WorldForces.Gravity * (float)m_mass;
            //m_force /= (float)m_mass;

            //m_angular_velocity += m_force * (delta);
        }

        public double GetWCSRightX()
        {
            return m_position.X + m_width;
        }

        public double GetRightX()
        {
            return m_width;
        }

        public double GetWCSLeftX()
        {
            return m_position.X;
        }

        public double GetLeftX()
        {
            return 0.0;
        }

        public double GetCenterX()
        {
            return m_width/2.0;
        }

        public double GetCenterY()
        {
            return m_height / 2.0;
        }

        public double GetWCSCenterX()
        {
            return m_position.X + m_width / 2.0;
        }

        public double GetWCSCenterY()
        {
            return m_position.Y + m_height / 2.0;
        }

        public double GetTopY()
        {
            return 0.0;
        }

        public double GetBotY()
        {
            return m_height;
        }

        public double GetWCSTopY()
        {
            return m_position.Y;
        }

        public double GetWCSBotY()
        {
            return m_position.Y+m_height;
        }

        public Vector2 GetCenter()
        {
            return new Vector2((float)m_width / 2.0f, (float)m_height / 2.0f);
        }

        public Vector2 GetWCSCenter()
        {
            return new Vector2(m_position.X + (float)(m_width / 2.0f), m_position.Y + (float)(m_height / 2.0f));
        }
    }
}
