namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {


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
            for (int meter = 1; meter <= 10; meter++) {
                double inch = inchConverter.ToMeter(meter);           //静的メソッド
                Console.WriteLine($"{meter}inch = {inch:0.0000},m");
            }
        }

    }
}
        
    
