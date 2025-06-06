﻿namespace SalesCalculator {
    internal class Program {
        
        static void Main(string[] args) {
            // => 式形式
           
            var sales = new SalesCounter(@"data\sales.csv");
            IDictionary<string, int> amountsPerStore = sales.GetPerStoreSales();
            foreach (KeyValuePair<string, int> obj in amountsPerStore) {
                Console.WriteLine($"{obj.Key} {obj.Value}");
            }
        }
    }
}               //var = 右のものだけで左の中身が決まるときに使う
