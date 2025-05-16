using System.Security.Cryptography.X509Certificates;

namespace Section01 {
    internal class Program {

        static void Main(string[] args) {
            var cities = new List<string> { 
            "Tokyo",
            "New Delhi",
            "Bangkok",
            "London",
            "Paris",
            "Berlin",
            "Canberra",
            "Hong Kong",
            };

            //var exists = cities.Exists(s => s[0] == 'P');   //1つ1つリストの中身をsに入れる
            // Console.WriteLine(exists);

             var lowerList = cities.ConvertAll(s => s.ToUpper()); //条件に合うものを全部渡す 
            lowerList.ForEach(s => Console.WriteLine(s));   //upper 大文字に　Lower 小文字に
        }
    }
}

// foreach (var s in names) {  foreach リストのやつを入れる
//    Console.WriteLine(s);
// }