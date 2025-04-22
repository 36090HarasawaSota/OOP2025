using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;

namespace DistanceConverter {
    internal class Program  {

        static void Main(string[] args) {


            int start = int.Parse(args[1]);               //int.Parse()=int型に変換
            int end = int.Parse(args[2]);


            if (args.Length >= 1 && args[0] == "-tom") {      //&&＝かつ
                PrintFeetToMeterList(start, end);
            } else {
                PrintMeterToFeetList(start, end);
            }

            //フィートからメートルへの対応表を出力  
            static void PrintFeetToMeterList(int start,int end) {
                for (int feet = start; feet <= end; feet++) {
                    double meter = FeetConverter.FromMeter(feet);
                    Console.WriteLine($"{feet}m = {meter:0.0000}ft");
                }
            }

            //メートルからフィートへの対応表を出力
            static void PrintMeterToFeetList(int start,int end) {
                for (int meter = start; meter <= end; meter++) {
                    double feet = FeetConverter.ToMeter(meter);
                    Console.WriteLine($"{meter}m = {feet:0.0000}ft");
                }
            }
        }

    }
}

