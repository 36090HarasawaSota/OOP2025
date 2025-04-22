using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter
{
   public class FeetConverter
    {
        public double FromMeter(double feet) {
            return feet * 0.34048;
        }

        public double ToMeter(double meter) {
            return meter / 0.34048;
        }
    }
    }
