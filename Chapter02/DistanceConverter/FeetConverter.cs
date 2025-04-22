using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter
{
   public static class FeetConverter{

        //定数
        private const double ratio = 0.3408;

        public static double FromMeter(double feet) {
            return feet * ratio;                                     
        }

        public static double ToMeter(double meter) {
            return meter / raito;
        }
    }
    }
