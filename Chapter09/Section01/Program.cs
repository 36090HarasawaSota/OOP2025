using System;
using System.Globalization;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {

            //var today = new DateTime(2025,7,12); //日付
            //var now = DateTime.Now; //日付と時刻

            //Console.WriteLine($"today:{today.Month}");
            //Console.WriteLine($"now:{now}");

            //自分の生年月日は何曜日かをプログラムで
            Console.WriteLine("日付を入力");
            Console.WriteLine();

            Console.Write("西暦:");
            var year = int.Parse(Console.ReadLine());
            Console.Write("月:");
            var month = int.Parse(Console.ReadLine());
            Console.Write("日付:");
            var day = int.Parse(Console.ReadLine());

            var birth = new DateTime(year, month, day);

            var culture = new CultureInfo("ja-jp");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();

            var str = birth.ToString("ggyy年M月d日", culture);
            var shortDayOfWeek = culture.DateTimeFormat.GetShortestDayName(birth.DayOfWeek);
            
            Console.WriteLine(str + birth.ToString("曜日",culture));

            //③生まれてから〇〇〇日目です
            TimeSpan diff = DateTime.Today - birth;
            Console.WriteLine($"あなたは生まれてから{diff.TotalDays}日目です");

            //④あなたは〇〇才です
            int age = GetAge(birth, DateTime.Today);
            Console.WriteLine($"あなたは{age + "歳"}です");

            //⑤１月１日から何日目です
            var today = DateTime.Today;
            var dayOfyear = today.DayOfYear;
            Console.WriteLine(dayOfyear);
        }

        private static int GetAge(DateTime birth, DateTime today) {
            var age = today.Year - birth.Year;
            return age;
        }
    }
}
