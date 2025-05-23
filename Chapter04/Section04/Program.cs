using Section04.SalesCalculator;
using System.Dynamic;

//nullの設定


#region null合体演算子(??)
string code = "12345";
var message = GetMessage(code) ?? DefaultMessage();  //?? = 帰ってきたcodeの中身がnullならDefaultMessageを表示
Console.WriteLine(message);
#endregion

#region null条件演算子
//Sale? sale = new Sale {
//    shopName = "新宿店",
//    ProductCategory = "洋菓子",
//    Amount = 523100,
//};

//Sale? sale = null;

//int? amount = Sale?.Amount;

//Console.WriteLine(amount);

#endregion

#region 値の入れ替え
int a = 10;
int b = 20;

Console.WriteLine("a=" + a + "b=" + b);

(b, a) = (a, b);
//int temp = a; (古いやり方)
//a = b;
//b = templ;

#endregion

string? inputDate = Console.ReadLine();

if(int.TryParse(inputDate,out var number)){
    Console.WriteLine(number);
}else {
    Console.WriteLine("エラー");
}
//    try {
//        int num = int.Parse(inputData);
//        Console.WriteLine(num);
//    }
//    catch (FormatException e) {
//        Console.WriteLine(e.Message);   //打たれたやつが例外のものならエラーメッセージを表示

//    }
//    catch (OverflowException) {
//        Console.WriteLine("入力値が大きすぎます");
//    }
//    finally {
//        Console.WriteLine("処理完了");
//    }
//Console.WriteLine("メソッド終了");



object? GetMessage(string code) {
    return code;
}



object? DefaultMessage() {
    return "DefaultMessage";
}

namespace Section04 {
    namespace SalesCalculator {
            //売り上げクラス
            public class Sale {
            //店舗名
            public string ShopName { get; set; } = String.Empty;
            //商品カテゴリ
            public string ProductCategory { get; set; } = String.Empty;
            //売上高
            public int Amount { get; set; }
        }
    }
}