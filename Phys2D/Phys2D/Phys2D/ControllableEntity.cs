using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Phys2D
{
    class ControllableEntity
    {
        public Entity m_entity;
       
        public _2DMotionHandler m_motionHandler;
        public double floorY, screenRight, screenLeft = 0.0;

        public ControllableEntity()
        {
            m_entity = new Entity(new Vector2(100.0f, 500.0f), new Vector2(0.0f, 0.0f));
            m_entity.m_bPlayerControlled = true;
            m_entity.m_coefRestitution = 0.75;
            m_entity.m_angular_momentum = new Vector2(1.0f, 1.0f);
            m_motionHandler = _2DMotionHandler.GetInstance();
            EntityManager.GetInstance().m_entities.Add(m_entity);
        }

        void CheckWorldCollisions()
        {
            if (m_entity.GetWCSBotY() > floorY)
            {
                m_entity.m_position.Y = (float)floorY - (float)m_entity.m_height;
                m_entity.m_velocity = Physics.CalculateReboundForce(m_entity, new Vector2(0.0f, 1.0f));
                // m_entity.m_velocity *= (float)m_entity.m_coefFriction;
            }
            if (m_entity.GetWCSTopY() < 0.0)
            {
                m_entity.m_position.Y = 0.0f;
                m_entity.m_velocity = Physics.CalculateReboundForce(m_entity, new Vector2(0.0f, -1.0f));
                //m_entity.m_velocity *= (float)m_entity.m_coefFriction;
            }
            if (m_entity.GetWCSLeftX() < screenLeft)
            {
                m_entity.m_position.X = (float)screenLeft;
                m_entity.m_velocity = Physics.CalculateReboundForce(m_entity, new Vector2(1.0f, 0.0f));
            }
            else if (m_entity.GetWCSRightX() > screenRight)
            {
                m_entity.m_position.X = (float)screenRight - (float)m_entity.m_width;
                m_entity.m_velocity = Physics.CalculateReboundForce(m_entity, new Vector2(-1.0f, 0.0f));
            }
        }

        public void Update(GameTime time)
        {
            m_entity.Update(ref time);
            m_entity.m_velocity += m_entity.m_impulseForce;
            m_entity.m_impulseForce = Vector2.Zero;

            CheckWorldCollisions();
            m_motionHandler.CalculateEulerMotion(time.ElapsedGameTime.Milliseconds, m_entity);
        }
    }
}
