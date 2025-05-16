using System.Security.Cryptography.X509Certificates;

namespace Section01 {
    internal class Program {
            
        static void Main(string[] args) { 
           // Console.WriteLine("カウントしたい数字");
           //int num = int.Parse(Console.ReadLine());
           
            var numbers = new[] { 5, 3, 9, 6, 7, 5, 8, 1, 0, 5, 10, };

            Console.WriteLine(Count(numbers,n => 5 <= n && n < 10 )); //n => n > nが５以上かつ１０未満の時だけtrue
                                                                      // => ラムダ演算子
        }

        static int Count(int[] numbers,Predicate<int> judge) {
                    var count = 0;
                    foreach (var n in numbers) {
                    //引数で受け取ったメソッドを呼び出す   
                    if (judge(n)  == true) {
                        count++;
                        }
                    }

            return count;
        }

    }
}