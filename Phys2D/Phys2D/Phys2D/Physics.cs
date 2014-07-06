using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Phys2D
{
    public static class Physics
    {
        public static double ToRadians(ref double angle)
        {
            return (angle * Constants.PI) / 180.0;
        }

        public static double ToAngle(ref double radians)
        {
            return ( radians * 180.0 ) / Constants.PI;
        }

        public static double AngleBetween(ref Vector2 a, ref Vector2 b)
        {
            return Math.Atan2(b.X-a.X, b.Y-a.Y) ;
        }

        public static Vector2 CalculateReboundForce(Entity entity, Vector2 normal)
        {
            Vector2 temp = entity.m_velocity - ((normal * (Vector2.Dot(entity.m_velocity, normal))) * 2.0f);
            return temp * (float)entity.m_coefRestitution;
        }
    }
}
