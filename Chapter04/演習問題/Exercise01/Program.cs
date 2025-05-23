
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            List<string> langs = [
                "C#", "Java", "Ruby", "PHP", "Python", "TypeScript",
                "JavaScript", "Swift", "Go",
];

            Exercise1(langs);
            Console.WriteLine("---");
            Exercise2(langs);
            Console.WriteLine("---");
            Exercise3(langs);

            Exercise4_1();
            Console.WriteLine("---");
            Exercise4_2();
            Console.WriteLine("---");
            Exercise4_3();
        }

        private static void Exercise1(List<string> langs) {
            foreach (var s in langs) {
                if (s.Contains("S")) {
                    Console.WriteLine(s);
                }
            }
            Console.WriteLine("");

            for (int i = 0; i < langs.Count; i++) {
                if (langs[i].Contains("S")) {
                    Console.WriteLine(langs[i]);
                }
            }
            Console.WriteLine("");

            int index = 0;
            while (index < langs.Count) {
                if (langs[index].Contains("S")) {
                    Console.WriteLine(langs[index]);
                }
                index++;
            }
            Console.WriteLine("");
        }

        private static void Exercise2(List<string> langs) {
            var selected = langs.Where(s => s.Contains("S")).ToList();
            foreach (var s in selected) {
                Console.WriteLine(s);
            }
        }

        private static void Exercise3(List<string> langs) {
            var lang = langs.Find(s => s.Length == 10);
            Console.WriteLine(lang ?? "unkonown");

            //Console.WriteLine(langs.Find(s => s.Length == 10) ?? "unkonown");
        }


        private static void Exercise4_1() {
            var line = Console.ReadLine();
            if (int.TryParse(line, out int tline)) { }

            if (tline < 0) {
                Console.WriteLine(tline);
            } else if (tline < 100) {
                Console.WriteLine(tline * 2);
            } else if (tline < 500) {
                Console.WriteLine(tline * 3);
            } else if (true) {
                Console.WriteLine(line);
            } else {
                Console.WriteLine("入力に誤りがあります");
            }


        }

        private static void Exercise4_2() {
        }

        private static void Exercise4_3() {
        }



    }
}

