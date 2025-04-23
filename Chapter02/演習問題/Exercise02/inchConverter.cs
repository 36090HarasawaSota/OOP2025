using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 { 
    public static class inchConverter {
        
        public static double Frominch(int inch) {
            return inch * 0.0254;
        }

        public static double ToMeter(int meter) {
            return meter / 0.0254;
        }
    }
}
