namespace Exercise01 {
    public class Program {

        public static void Main() {

        Exercise1_2();
        Console.WriteLine();
        Exercise1_3();
        Console.WriteLine();
    //    Exercise1_4();
    //    Console.WriteLine();
    //    Exercise1_5();
    //    Console.WriteLine();
    //    Exercise1_6();
    //    Console.WriteLine();
    //    Exercise1_7();
    //    Console.WriteLine();
    //    Exercise1_8();
    //    Console.ReadLine();
    }

        private static void Exercise1_2() {
            var book = Library.Books.MaxBy(b => b.Price);
        }

        private static void Exercise1_3() {
            var selected = Library.Books
                .GroupBy(b => b.PublishedYear)
                .OrderBy(c => c!.Key);

            foreach (var book in selected) {
                Console.WriteLine($"{book!.Key}年　{book.Count()}");
            }
        }

        void Exercise1_4() {

        }

        void Exercise1_5() {

        }

        void Exercise1_6() {

        }

        void Exercise1_7() {

        }

        void Exercise1_8() {

        }

    }
}
