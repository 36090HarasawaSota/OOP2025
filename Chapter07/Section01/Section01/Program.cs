namespace Section01 {
    internal class Program {
        static void Main(string[] args) {

            var books = Books.GetBooks();

            //①本の平均金額を表示
            Console.WriteLine((int)books.Average(x=> x.Price));

            //②本のページ合計を表示
            Console.WriteLine(books.Sum(n=> n.Pages));

            //③金額の安い書籍名と金額を表示
            var book = books.Where(n => n.Price == books.Min(n => n.Price));
            foreach(var n in book) {
                Console.WriteLine(n.Title + ": " +  n.Price + "円");
            }

            //④ページ数が多い書籍名とページ数を表示
            var maxbook = books.Where(n=> n.Pages == books.Max(n=> n.Pages));
            foreach (var num in maxbook) {
                Console.WriteLine(num.Title + ": " + num.Pages + "ページ");
            }

            //⑤タイトルに「物語」が含まれる書籍名をすべて表示
            var titles = books.Where(b => b.Title.Contains("物語"));
            foreach (var n in titles){
                Console.WriteLine(n.Title);
            }


        }
    }
}
