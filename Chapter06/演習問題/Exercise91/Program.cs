using System.Globalization;

namespace Exercise91 {
    internal class Program {
        static void Main(string[] args) {

            var target = "C# Programing";
            var isExists = target.All(c=> Char.IsLower(c));
            //var isExists = target.Any(c => Char.IsLower(c));
        }
    }
}
