using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Phys2D
{
    public struct Force
    {
        public String m_name;
        public Vector2 m_data;

        public Force(String name, Vector2 data)
        {
            m_name = name;
            m_data = data;
        }
    }

    public class ForceZone
    {
        public List<Force> m_forces;
        public EntityManager m_mgr;
        public Vector2 m_topLeft;
        public double m_width, m_height;
        public long m_id;
        Rectangle m_rect;
        Texture2D m_texture;

        public ForceZone(Vector2 topLeft, Texture2D texture)
        {
            m_topLeft = topLeft;
            m_texture = texture;
            m_width = texture.Width;
            m_height = texture.Height;
            m_id = IDManager.GenerateNewID();
            m_rect = new Rectangle((int)topLeft.X, (int)topLeft.Y, (int)m_width, (int)m_height);
            m_forces = new List<Force>(0);
            m_mgr = EntityManager.GetInstance();
        }

        public void AddForce(Force f)
        {
            m_forces.Add(f);
        }

        public void AddForce(String name, Vector2 quantity)
        {
            m_forces.Add(new Force(name, quantity));
        }

        public void ApplyForces()
        {
            foreach (Entity e in m_mgr.m_entities)
            {
                if (CollisionFunctions.SpaceOverlapping(e, this))
                {
                    foreach (Force f in m_forces)
                    {
                        if (f.m_name != "Whirlwind")
                            e.m_zoneForces += f.m_data;
                        else
                        {
                            Vector2 dir = (e.GetWCSCenter()-GetWCSCenter() )/3.0f;
 
                            e.m_zoneForces += -(f.m_data*dir);
                        }
                    }
                }
            }
        }

        public void Draw(ref SpriteBatch sb)
        {
            sb.Draw(m_texture, m_rect, Color.White);
        }

        public float GetCenterX()
        {
            return (float)(m_width / 2.0);
        }

        public float GetCenterY()
        {
            return (float)(m_height / 2.0);
        }

        public Vector2 GetCenter()
        {
            return new Vector2(GetCenterX(), GetCenterY());
        }

        public Vector2 GetWCSCenter()
        {
            return new Vector2(GetWCSCenterX(), GetWCSCenterY());
        }

        public float GetWCSCenterX()
        {
            return (float)(m_topLeft.X + (m_width / 2.0));
        }

        public float GetWCSCenterY()
        {
            return (float)(m_topLeft.Y - (m_height / 2.0));
        }
    }
}
