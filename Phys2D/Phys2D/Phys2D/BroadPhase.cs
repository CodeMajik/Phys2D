using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phys2D
{
    public class BroadPhase
    {
        public EntityManager m_entityMgr;
        public static BroadPhase m_instance = null;

        public List<Entity> xAxisCache, yAxisCache;

        private BroadPhase()
        {
            m_entityMgr = EntityManager.GetInstance();
            xAxisCache = new List<Entity>(0);
            yAxisCache = new List<Entity>(0);
        }

        public static BroadPhase GetInstance()
        {
            if (m_instance != null)
                m_instance = new BroadPhase();
            return m_instance;
        }

        public void GenerateAxisData()
        {
            xAxisCache.Clear();
            yAxisCache.Clear();
            int size = m_entityMgr.m_entities.Count;
            Entity a = null;
            Entity b = null;
            for (int i = 0; i < size; ++i)
            {
                a = m_entityMgr.m_entities.ElementAt(i);
                for (int j = 0; j < size; ++j)
                {
                    b = m_entityMgr.m_entities.ElementAt(j);
                }
            }
        }

        public void RunSweepAndPrune()
        {
           /*
            * - compare entities against eachother on x axis
            * - if overlapping on x test on y
            * - if overlapping on both then they are probably colliding
            * - send entity pair to narrow phase 
           */


        }
    }
}
