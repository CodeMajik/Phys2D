using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Phys2D
{
    public class CollisionHandler
    {
        public static CollisionHandler m_instance = null;
        public static CollisionHandler GetInstance()
        {
            if (m_instance == null)
                m_instance = new CollisionHandler();
            return m_instance;
        }

        public void HandleCollision(ref Entity a, ref Entity b)
        {
            if (CollisionFunctions.CubeOverlapping(ref a, ref b))
            {
                Vector2 force = CollisionFunctions.GetCollisionDirection(ref a, ref b);
                a.m_velocity += force;
                b.m_velocity += force;
            }
        }

        public void HandleAllCollisions(ref List<Entity> entites)
        {
            int size = entites.Count;
            Entity a, b;
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    a = entites.ElementAt(i);
                    b = entites.ElementAt(j);
                    if (a!=b && (!a.m_bPlayerControlled&&!b.m_bPlayerControlled) && CollisionFunctions.CubeOverlapping(ref a, ref b))
                    {
                        //compile list of forces to add to velocity
                        Vector2 force = CollisionFunctions.GetCollisionDirection(ref a, ref b);
                        a.m_velocity = Physics.CalculateReboundForce(a, force);
                        b.m_velocity = Physics.CalculateReboundForce(b, -force);
                    }
                }
            }
        }
    }
}
