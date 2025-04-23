using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02
{
    class YardConverter {

        private const double ratio = 0.9144;

       public static double Tometer(int yard) {
            return yard * ratio;
        }
    }
}