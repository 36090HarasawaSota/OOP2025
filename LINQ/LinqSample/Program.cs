namespace LinqSample {
    internal class Program {
        static void Main(string[] args) {
            var numbers = Enumerable.Range(1, 100);  //numbersに１から１０の部屋を渡せる

            //合計値の出力
            //Console.WriteLine(numbers.Sum());

            //偶数の合計の出力
            Console.WriteLine(numbers.Where(n => n % 8 == 0).Sum());  //where　抽出

            //平均の出力
            //Console.WriteLine(numbers.Average());


            //foreach (var num in numbers) {
             //   Console.WriteLine(num);
            //}
        }
    }
}
