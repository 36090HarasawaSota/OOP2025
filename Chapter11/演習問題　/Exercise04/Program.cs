using System;
using System.Text.RegularExpressions;

namespace Exercise04 {
    internal class Program {
        static void Main(string[] args) {

            var lines = File.ReadAllLines("sample.txt");
            var newlines = lines.Select(line => Regex.Replace(line, "\\b[v|V]ersion\\s*=\\s*\"v4\\.0", "version=\"v5.0")).ToList();
            File.WriteAllLines("sampleChange.txt", newlines);

            //これ以降は確認用
            var text = File.ReadAllLines("sampleChange.txt");
            foreach (var Text in text) {
                Console.WriteLine(Text);
            }

        }

    }
}
