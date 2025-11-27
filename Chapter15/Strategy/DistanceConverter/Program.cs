using System;
using System.Linq;

namespace DistanceConverter {
    internal class Program {
        static void Main(string[] args) {
            // 利用可能な単位一覧を表示
            Console.WriteLine("利用可能な単位一覧:");
            foreach (var c in ConverterFactory.GetAllConverters()) {
                Console.WriteLine($"- {c.UnitName} (英語入力: {c.GetEnglishName()})");
            }
            Console.WriteLine();

            var from = GetConverter("変換元の単位を入力してください");
            var to = GetConverter("変換先の単位を入力してください");
            var distance = GetDistance(from);

            var converter = new DistanceConverter(from, to);
            var result = converter.Convert(distance);
            var text = $"{distance}{from.UnitName}は、{result:0.000}{to.UnitName}です";
            Console.WriteLine(text);

            static double GetDistance(ConverterBase from) {
                double? value = null;
                do {
                    Console.Write($"変換したい距離(単位:{from.UnitName})を入力してください => ");
                    var line = Console.ReadLine();
                    value = double.TryParse(line, out var temp) ? temp : null;
                } while (value is null);
                return value.Value;
            }

            static ConverterBase GetConverter(string msg) {
                ConverterBase? converter = null;
                do {
                    Console.Write(msg + " => ");
                    var unit = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(unit))
                        converter = ConverterFactory.GetInstance(unit);
                    if (converter is null) {
                        Console.WriteLine("入力が認識できませんでした。例: meter, feet, inch, yard, mile, kilometer または 日本語単位名");
                    }
                } while (converter is null);
                return converter;
            }
        }
    }
}