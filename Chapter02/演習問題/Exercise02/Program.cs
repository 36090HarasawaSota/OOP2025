namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {

            Console.WriteLine("*** 変換アプリ ***");
            Console.WriteLine("1:インチからメートル");
            Console.WriteLine("2:メートルからインチ");
            
            Console.WriteLine(">1");

            Console.WriteLine();
            Console.WriteLine("はじめ: 1");
            Console.WriteLine("終わり: 2");
            
            PrintinchToMeterList();

            PrintMeterToinchList();

        }
        static void PrintinchToMeterList() {
            for (int inch = 1; inch <= 10; inch++) {
                double meter = inchConverter.Frominch(inch);           //静的メソッド
                Console.WriteLine($"{inch}inch = {meter:0.0000},m");
            }
        }



        static void PrintMeterToinchList() {
            Console.WriteLine();
            Console.WriteLine(">2");
            for (int meter = 1; meter <= 10; meter++) {
                double inch = inchConverter.ToMeter(meter);           //静的メソッド
                Console.WriteLine($"{meter}m = {inch:0.0000},inch");
            }
        }

    }
}


