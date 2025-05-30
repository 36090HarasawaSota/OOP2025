
namespace Exercise {
    internal class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz";
            int i;
            Console.WriteLine("6.3.1");
            Exercise1(text);

            Console.WriteLine("6.3.2");
            Exercise2(text);

            Console.WriteLine("6.3.3");
            Exercise3(text);

            Console.WriteLine("6.3.4");
            Exercise4(text);

            Console.WriteLine("6.3.5");
            Exercise5(text);

        }

        private static void Exercise1(string text) {
            Console.WriteLine("空白数: " + text.Count(c=> c == ' '));
 
        }

        private static void Exercise2(string text) {
            var newtext = text.Replace("big","small");
            Console.WriteLine(newtext);
        }

        private static void Exercise3(string text) {
            
        }

        private static void Exercise4(string text) {
            var words = text.Split(' ');
            Console.WriteLine("単語数"+ words.Length);

        }

        private static void Exercise5(string text) {
            var words = text.Split(' ');
            var word = words.Where(c=> c.Length <= 4);
            foreach(var n in word){
                Console.WriteLine(string.Join(",",n));
            }
        }

    
    
    
    }
}
