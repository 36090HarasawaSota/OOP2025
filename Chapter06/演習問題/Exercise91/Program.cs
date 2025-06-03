using System.Diagnostics.Tracing;

namespace Exercise04 {
    internal class Program {
        static void Main(string[] args) {
            var line = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";
            var aray = line.Split(';');
            foreach (var lin in aray) {
                var lines = lin.Split('=');
                Console.WriteLine($"{ToJapanese(lines[0])}:{lines[1]}"); 
            }
        }


        /// 引数の単語を日本語へ変換します
        static string ToJapanese(string key) {

            //return switch (key) {
            //    "Novelist" => "作家",
            //    "BestWork" => "代表作",
            //    "Born" => "誕生年",
            //    _=>"引数keyは正しい数値ではありません"
           // };

            switch (key){
                case "Novelist":
                    return "作家";
                case "BestWork":
                    return "代表作";
                case "Born":
                    return "誕生年";
            }
           // Console.WriteLine(key[]: + key[]);
            return ""; //エラーをなくすためのダミー
        }
    }
}