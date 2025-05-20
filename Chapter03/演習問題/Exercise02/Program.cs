
using System.Xml.Linq;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            
            var cities = new List<string> {
                "Tokyo", "New Delhi", "Bangkok", "London",
                "Paris", "Berlin", "Canberra", "Hong Kong",
            };

            Console.WriteLine("***** 3.2.1 *****");
            Exercise2_1(cities);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.2 *****");
            Exercise2_2(cities);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.3 *****");
            Exercise2_3(cities);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.4 *****");
            Exercise2_4(cities);
            Console.WriteLine();

        }

        private static void Exercise2_1(List<string> names) {
                Console.WriteLine("都市名を入力。空白で終了:");
            do {
                var name = Console.ReadLine();
                if (String.IsNullOrEmpty(name)) {
                    break;
                }
                int tnumber = names.FindIndex(s => s == name);         //truenumber = tnumber 
                Console.WriteLine(tnumber);
            }   while (true);
        }

        private static void Exercise2_2(List<string> names) {
                //ヒント
                int count = names.Count(s => s.Contains("o"));        //.Contains() = ()内のものがあるかチェック
                Console.WriteLine(count);

                //Console.WriteLine(names.Count(s => s.Contains("o")));
        }


        private static void Exercise2_3(List<string> names) {
           
        }

        private static void Exercise2_4(List<string> names) {
           
        }
    }
}
