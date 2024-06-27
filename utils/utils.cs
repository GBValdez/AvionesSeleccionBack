using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvionesBackNet.utils
{
    public class Utils
    {
        public static bool indexValid<T>(List<T> list, int index)
        {
            return index >= 0 && index < list.Count;
        }
    }
}