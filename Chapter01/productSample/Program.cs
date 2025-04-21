namespace productSample
{
    internal class Program {
       
        static void Main(string[] args) { 
        
         Product karinto = new Product(123, "かりんとう", 180);
         Product daifuku = new Product(124, "大福", 7000);

          //税込みの価格を表示(かりんとうの税抜き価格は〇〇円です)
            Console.WriteLine(karinto.Name + "の税抜き価格は" + karinto.Price + "です");
        
         //消費税額の価格
         Console.WriteLine(karinto.Name + "の消費税額は" + karinto.GetTax() + "円です");

            //税込み価格の表示
            Console.WriteLine(karinto.Name + "の税込み価格は、" + karinto.GetPriceIncIudingTax() + "円です。");

        //合計金額の表示
         Console.WriteLine("合計金額は" + (karinto.GetPriceIncIudingTax() + daifuku.GetPriceIncIudingTax()) + "です");   

        }
    }
}
