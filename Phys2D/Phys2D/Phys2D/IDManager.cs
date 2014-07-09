using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phys2D
{
    public static class IDManager
    {
        private static long m_index = 0;
        public static long GenerateNewID()
        {
            return ++m_index;
        }
    }
}
