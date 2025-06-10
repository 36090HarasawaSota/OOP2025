﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01{
    //5.1.1
    public class YearMonth {
        public int Year { get; init; }
        public int Month { get; init; }

        public YearMonth(int year = 0, int month = 0) {
            Year = year;
            Month = month;
        }

        //5.1.2
        public bool Is21Century => 2001 <= Year && Year <= 2100;

        //5.1.3
        public YearMonth AddOneMonth() {
            var newmonth = Month;
            if (newmonth <= 12) {
                return new YearMonth(newmonth);
            } else {
                return new YearMonth(newmonth = 1);
            }
        }







    }
}
