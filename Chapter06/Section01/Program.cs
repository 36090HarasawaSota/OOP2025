using System.Globalization;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var str1 = "かすてら";
            var str2 = "カステラ";

            var cultureinfo = new CultureInfo("ja-jp");
            if(String.Compare(str1, str2, cultureinfo, CompareOptions.IgnoreWidth | CompareOptions.IgnoreCase) == 0){
                Console.WriteLine("一致しています");
            }
        }
    }
}
