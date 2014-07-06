using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Phys2D
{
    public class _2DMotionHandler
    {
        public static float delta = 0.00000001f;
        public static _2DMotionHandler m_instance=null;

        public static _2DMotionHandler GetInstance()
        {
            if (m_instance == null)
                m_instance = new _2DMotionHandler();
            return m_instance;
        }

        public void CalculateEulerMotion(double dt, ref Vector2 pos, ref Vector2 vel)
        {
            delta = (float)(dt/1000.0);
            Vector2 accel = new Vector2(0.0f, WorldForces.Gravity.Y);
            vel = new Vector2(vel.X + (accel.X * delta), vel.Y + (accel.Y * delta));

            accel = new Vector2((accel.X*delta)/2.0f, (accel.Y*delta)/2.0f);
            pos += vel + accel;
        }

        public void CalculateEulerMotion(double dt, Entity entity)
        {
            delta = (float)(dt / 1000.0);
            Vector2 accel = entity.m_force*(float)entity.m_mass;
            Vector2 vel = entity.m_velocity;
            accel /= (float)entity.m_mass;
            vel += (accel*delta);// new Vector2(vel.X + (accel.X * delta), vel.Y + (accel.Y * delta));

            accel = new Vector2((accel.X * delta) / 2.0f, (accel.Y * delta) / 2.0f);//0.5 at squared
            
            entity.m_position += vel + accel;
            entity.m_velocity = vel;
        }

        public void CalculateVerletMotion(ref Vector2 pos, ref Vector2 vel)
        {

        }

        public void CalculateRK4Motion(ref Vector2 pos, ref Vector2 vel)
        {

        }
    }
}
