using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleUnitConverter{
    class ImperialUnit : DistanceUnit {
        private static List<ImperialUnit> units = new List<ImperialUnit> {
            new ImperialUnit{Name = "in", Coefficient=1,},
            new ImperialUnit{Name = "ft", Coefficient=10,},
            new ImperialUnit{Name = "yd", Coefficient=10 * 100},
            new ImperialUnit{Name = "ml", Coefficient=10 * 100 * 1000},
        };

        public static ICollection<ImperialUnit> Units { get => units; }

        //<sumary>
        //メートル単位からヤード単位に変換します
        //</sumary>
        //<param name="unit">変換元の単位</param>
        //<param name="value">変換する値</param>
        //<returns>変換した値 </returns>

        public double FromMetricUnit(ImperialUnit unit, double value) {
            return (value * unit.Coefficient) / 25.4 / Coefficient;
        }

    }
}
