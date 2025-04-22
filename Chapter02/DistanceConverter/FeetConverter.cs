using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter
{
   public　static class FeetConverter
    {
        public static double FromMeter(double feet) {
            return feet * 0.34048;                                      //引数
        }

        public static double ToMeter(double meter) {
            return meter / 0.34048;
        }
    }
    }
