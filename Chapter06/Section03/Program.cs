using System.Dynamic;
using System.Text;

namespace Section03 {
    internal class Program {
        static void Main(string[] args) {
            //文字の連結　いい例
            var sb = new StringBuilder();
            foreach (var word in GetWords()) {
                sb.Append(word);
            }
            var text = sb.ToString();
            Console.WriteLine(text);


            //悪い例
            string str = "";
            foreach (var word in GetWords()) {
                str += word;
            }
            Console.WriteLine(str);
        }

           // var languages = new[] { "C#", "Java", "Python", "Ruby", };
           // var separator = ", ";
           // var result = String.Join(separator, languages); //String.Join = 左のやつを文字列同士の間だけにつける
           // Console.WriteLine(result);
           // }

        private static IEnumerable<object> GetWords() {
            return ["Orange","Lemon","Strawberry"];
        }
    }
}
