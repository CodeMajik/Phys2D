using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Phys2D
{
    public class AxisAlignedBoundingBox
    {
        public float m_width, m_height, m_left, m_right, m_top, m_bottom;
        public Entity m_owner;

        public AxisAlignedBoundingBox()
        {
            m_owner = null;
            m_width = 0.0f;
            m_height = 0.0f;
            m_right = 0.0f;
            m_left = 0.0f;
            m_top = 0.0f;
            m_bottom = 0.0f;
        }

        public AxisAlignedBoundingBox(ref Entity e)
        {
            m_owner = e;
            Recalculate();
        }

        public void Recalculate()
        {
            if (m_owner != null)
            {
                m_width = (float)m_owner.m_width;
                m_height = (float)m_owner.m_height;
                m_left = (float)m_owner.GetWCSLeftX();
                m_right = (float)m_owner.GetWCSRightX();
                m_top = (float)m_owner.GetWCSBotY();
                m_bottom = (float)m_owner.GetWCSTopY();
            }
        }

        public Vector2 TopLeft()
        {
            return new Vector2(m_left, m_top);
        }

        public Vector2 TopRight()
        {
            return new Vector2(m_right, m_top);
        }

        public Vector2 BottomLeft()
        {
            return new Vector2(m_left, m_bottom);
        }

        public Vector2 BottomRight()
        {
            return new Vector2(m_right, m_bottom);
        }

        public Vector2 GetWCSCenter()
        {
            return new Vector2((float)(m_left + (m_width / 2.0)), (float)(m_bottom + (m_height / 2.0)));
        }

        public Vector2 GetCenter()
        {
            return new Vector2((float)(m_width / 2.0), (float)(m_height / 2.0));
        }
    }
}
