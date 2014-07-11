using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Phys2D
{
    public class AABBManager
    {
        public static AABBManager m_instance=null;
        public List<AxisAlignedBoundingBox> m_aabbs;
        Texture2D m_tex;

        public static AABBManager GetInstance()
        {
            if(m_instance==null)
                m_instance = new AABBManager();
            return m_instance;
        }

        private AABBManager()
        {
            m_aabbs = new List<AxisAlignedBoundingBox>(0);
        }

        public void AddAABB(AxisAlignedBoundingBox aabb)
        {
            m_aabbs.Add(aabb);
        }

        public void AddAABB(ref Entity e)
        {
            m_aabbs.Add(new AxisAlignedBoundingBox(ref e));
        }

        public void SetTexture(ref Texture2D t)
        {
            m_tex = t;
        }

        public void Update()
        {
            foreach (AxisAlignedBoundingBox aabb in m_aabbs)
                aabb.Recalculate();
        }

        public void Draw(ref SpriteBatch sb)
        {
            foreach (AxisAlignedBoundingBox aabb in m_aabbs)
            {
                sb.Draw(m_tex, aabb.GetWCSCenter(), null, Color.White, 0.0f,
                        aabb.GetCenter(), 1.0f, SpriteEffects.None, 0f);
            }
        }
    }
}
