using System.Security.Cryptography.X509Certificates;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {

            var year = Console.ReadLine();
            var month = Console.ReadLine();
            YearMonth ym = new YearMonth(year,month);

        }
    }
}
