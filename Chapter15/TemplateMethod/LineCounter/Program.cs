using TextFileProcessor;

namespace LineCounter {
    internal class Program {
        static void Main(string[] args) {

            Console.Write("ファイルパスを入力してください: ");
            string path = Console.ReadLine()?.Trim('"');


            Console.Write("検索文字列を入力してください: ");
            string target = Console.ReadLine();

            LineCounterProcessor.TargetKeyword = target;

            TextProcessor.Run<LineCounterProcessor>(path);
        }

    }
}
