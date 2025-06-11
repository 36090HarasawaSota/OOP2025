using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Exercise01 {

    //5.1.1
    public record YearMonth (int year, int month){
        public int Year { get; init; } = year;　　//= year 〇〇コンストラクタ　普通のコンストラクタでいちいちメソッドを作らず直接入れられる
        public int Month { get; init; } = month;  //= month　〇〇コンストラクタ

        //public YearMonth(int year = 0, int month = 0) {
        //    Year = year;
        //    Month = month;
        //}


        //5.1.2
        public bool Is21Century => 2001 <= Year && Year <= 2100; //プロパテイー　右側の条件に当てはまるなら
                                                                 //型に沿ったものを返す　　今回はboolなのでtrueかfalseを返す  プロパティーは呼び出すとき()を書いたらエラーになる   
       
        //5.1.3
        public YearMonth AddOneMonth() {
            if (Month < 12) {
                return new YearMonth(Year, Month + 1);
            } else {
                return new YearMonth(Year + 1, 1);
            }
        }


        //5.1.4
        public override string ToString() => Year +"年" + Month  + "月";






    }
}
