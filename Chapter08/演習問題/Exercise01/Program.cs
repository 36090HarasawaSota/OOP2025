
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
            foreach (var item in text.ToUpper()) {
                if('A' <= item && item <= 'Z'){
                    if (numcount.ContainsKey(item)) {
                        numcount[item]++;
                    } else {
                        numcount[item] = 1;
                    }
                }
            }
            foreach (var num in numcount.OrderBy(n => n.Key)){
                Console.WriteLine($"{num.Key}: {num.Value}");
            }
        }


        private static void Exercise2(string text) {
            var numcount = new  SortedDictionary<char, int>();  //後からこれに追加した際、勝手に昇順にしてくれる
            foreach (var item in text.ToUpper()) {
                if ('A' <= item && item <= 'Z') {
                    if (numcount.ContainsKey(item)) {
                        numcount[item] ++;
                    } else {
                        numcount[item] = 1;
                    }
                }
            }
            foreach (var num in numcount) {
                Console.WriteLine($"{num.Key}: {num.Value}");
            }
        }
    }
}
