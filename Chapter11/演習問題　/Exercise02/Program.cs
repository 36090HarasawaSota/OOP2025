using Microsoft.VisualBasic;
using System.Text.RegularExpressions;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            string filePath = "sample.txt";
            Pickup3DigitNumber(filePath);
        }

        private static void Pickup3DigitNumber(string filepath) {

            foreach (var line in File.ReadLines(filepath) ) {
                var matches = Regex.Matches(line,@"\b\d{3,}\b");
                foreach (Match n in matches) {
                    Console.WriteLine(n.Value);
                }
            }

        }



    }
}
