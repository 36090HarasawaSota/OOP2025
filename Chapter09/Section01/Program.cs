namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var today = new DateTime(2025,7,12); //日付
            var now = DateTime.Now; //日付と時刻
            Console.WriteLine($"today:{today.Month}");
            Console.WriteLine($"now:{now}");

            //自分の生年月日は何曜日かをプログラムで
            var week = new DateTime(2005,7,17);
            Console.WriteLine($"today:{today.DayOfWeek}");
        }
    }
}
