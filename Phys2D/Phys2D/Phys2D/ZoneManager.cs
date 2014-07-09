using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Phys2D
{
    public class ZoneManager
    {
        public List<ForceZone> m_zones;

        public static ZoneManager m_instance;

        public static ZoneManager GetInstance()
        {
            if(m_instance==null){
                m_instance = new ZoneManager();
            }
            return m_instance;
        }

        private ZoneManager()
        {
            m_zones = new List<ForceZone>(0);
        }

        public void AddZone(ForceZone zone)
        {
            m_zones.Add(zone);
        }

        public void AddZone(Vector2 topLeft, Texture2D texture)
        {
            m_zones.Add(new ForceZone(topLeft, texture));
        }

        public void Update()
        {
            foreach (ForceZone zone in m_zones)
                zone.ApplyForces();
        }

        public void Draw(ref SpriteBatch sb)
        {
            foreach (ForceZone zone in m_zones)
                zone.Draw(ref sb);
        }
    }
}
