using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01{   
    //5.1.1
    class YearMonth{

        public int Year { get; private set; }
        public int Month { get; private set; }

        public YearMonth(string year, string month) {
            var Year = year;
            var Month = month;
        }
    }
}
