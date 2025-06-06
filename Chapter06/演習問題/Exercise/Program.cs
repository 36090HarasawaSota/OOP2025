
using System.Linq;
using System.Text;

namespace Exercise {
    internal class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz";
            Console.WriteLine("6.3.1");
            Exercise1(text);

            Console.WriteLine("6.3.2");
            Exercise2(text);

            Console.WriteLine("6.3.3");
            Exercise3(text);

            Console.WriteLine("6.3.4");
            Exercise4(text);

            Console.WriteLine("6.3.5");
            Exercise5(text);

            Console.WriteLine("6.3.99");
            Exercise6(text);

        }

        private static void Exercise6(string text) {
            //アルファベットの数をカウントして表示

            // char str ='a';
            //while (str <= 'z') {
            //    Console.WriteLine(str + ":" + text.ToLower().Replace(" ","").Count(c=> c == str));
            //   str++;
            //}

            var str = text.ToLower().Replace(" ", "");


            var alphDicCount = Enumerable.Range('a', 26)　　 //keyとvalueを２６個ずつ作る　aからz,0から25
                .ToDictionary(num => ((char)num).ToString(), num => 0);　//アルファベットが数字に代わってしまうので文字に変える　numの初期値を0にする

            foreach (var alph in str) {             //strの要素をalphDicCountにいれる
                alphDicCount[alph.ToString()]++;
            }

            foreach (var item in alphDicCount) {
                Console.WriteLine(item.Key + ":" + item.Value);
            }

        }

        private static void Exercise1(string text) {
            Console.WriteLine("空白数: " + text.Count(c=> c == ' '));
 
        }

        private static void Exercise2(string text) {
            var newtext = text.Replace("big","small");
            Console.WriteLine(newtext);
        }

        private static void Exercise3(string text) {
            var array = text.Split(' ');
            var sb = new StringBuilder();                   //StringBuilderクラスのインスタンス作成
            sb.Append(array[0]);            　           //空のStringBuilderクラスにarrayの0番目の要素を入れる
            foreach (var word in array.Skip(1)) {
                sb.Append(' ');　　　                      //StringBuilderクラスに空白を入れる
                sb.Append(word);                        //StringBuilderクラスにarrayの2番目からの要素を入れる
            }
            Console.WriteLine(sb + ".");
        }

        private static void Exercise4(string text) {
            var words = text.Split(' ');
            Console.WriteLine("単語数"+ words.Length);

        }

        private static void Exercise5(string text) {
            var words = text.Split(' ');
            var word = words.Where(c=> c.Length <= 4);
            foreach(var n in word){
                Console.WriteLine(n);
            }
        }

    
    
    
    }
}
