namespace Section01 {
    internal class Program {
        static void Main(string[] args) {


            Console.WriteLine("カウントしたい数字");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine(num + "は"+ Count(num) + "個です");
        }
            static int Count(int num) {
                var numbers = new[] { 5, 3, 9, 6, 7, 5, 8, 1, 0, 5, 10, };
                var count = 0;

                foreach (var n in numbers) {
                    if (n == num) {
                        count++;
                    }
                }

                return count;


            }
    }
}