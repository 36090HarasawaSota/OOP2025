
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Cozy lummox gives smart squid who asks for job pen";

            Exercise1(text);
            Console.WriteLine();

            Exercise2(text);

        }

        private static void Exercise1(string text) {
            var numcount = new Dictionary<char, int>();
            foreach (var item in text.ToUpper().OrderBy(n=> text)) {
                if('A' <= item && item <= 'Z'){
                    if (numcount.ContainsKey(item)) {
                        numcount[item] += 1;
                    } else {
                        numcount.Add(item, 1);
                    }
                }
            }
            foreach (var num in numcount) {
                Console.WriteLine($"{num.Key}: {num.Value}");
            }
        }


        private static void Exercise2(string text) {
         
        }
    }
}
