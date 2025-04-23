using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program2 {
        static void Main(string[] args) {

            Console.WriteLine("*** 変換アプリ ***");
            Console.WriteLine("1 : ヤードからメートル");
            Console.WriteLine("2 : メートルからヤード");
            Console.WriteLine(">1");

            Console.WriteLine("ヤードの値を入力してください");
            Console.WriteLine("変換前");
            int yard = int.Parse(Console.ReadLine());
            Console.WriteLine("変換前(ヤード):" + yard);
            PrintyardToMeterList(yard);
        }

        static void PrintyardToMeterList(int yard) {

            double meter = YardConverter.Tometer(yard);
            Console.WriteLine("変換後(メートル):" + meter + "m" );
        }




        
    }
}
