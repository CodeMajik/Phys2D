using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Phys2D
{
    public static class WorldForces
    {
        public static Vector2 Gravity = new Vector2(0.0f, 9.81f);
        public static Vector2 Wind = new Vector2();
        public static Vector2 Friction = new Vector2();
        public static Vector2 Magnetism = new Vector2();
    }
}
