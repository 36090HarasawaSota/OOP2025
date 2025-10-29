using System.Security.Cryptography.X509Certificates;

namespace Exercise01 {
    public class Program {

        public static void Main() {

            Exercise1_2();
            Console.WriteLine();
            Exercise1_3();
            Console.WriteLine();
            Exercise1_4();
            Console.WriteLine();
            Exercise1_5();
            Console.WriteLine();
            Exercise1_6();
            Console.WriteLine();
            Exercise1_7();
            Console.WriteLine();
            //    Exercise1_8();
            //    Console.ReadLine();
        }

        private static void Exercise1_2() {
            var book = Library.Books.MaxBy(b => b.Price);
        }

        private static void Exercise1_3() {
            var selected = Library.Books
                .GroupBy(b => b.PublishedYear)
                .OrderBy(c => c!.Key)
                .Select(b => new {
                    PublicYear = b.Key,
                    count = b.Count()
                });

            foreach (var book in selected) {
                Console.WriteLine($"{book!.PublicYear}年:{book.count}");
            }
        }

        private static void Exercise1_4() {
            var selected = Library.Books
                .OrderByDescending(c => c.PublishedYear)
                .ThenByDescending(b => b.Price);
            foreach (var book in selected) {
                Console.WriteLine($"{book.PublishedYear}年 {book.Price}円 {book.Title}");
            }
        }

        private static void Exercise1_5() {
            var books = Library.Books
                .Where(b => b.PublishedYear == 2022)
                .Join(Library.Categories
                        , book => book.CategoryId
                        , Category => Category.Id,
                         (book, category) => new {
                             CategoryName = category.Name
                         })
                .Distinct();

            foreach (var book in books) {
                Console.WriteLine($"{book.CategoryName}");
            }
        }

        private static void Exercise1_6() {
            var books = Library.Books
                .Join(Library.Categories,
                      book => book.CategoryId,
                      category => category.Id,
                      (book, category) => new {
                          Category = category.Name,
                          book.Title
                      })
                .GroupBy(b => b.Category)
                .OrderBy(c => c.Key);

            foreach (var group in books) {
                Console.WriteLine($"# {group.Key}");
                foreach (var book in group) {
                    Console.WriteLine($"   {book.Title}");
                }
            }
        }


        private static void Exercise1_7() {
            var books = Library.Books
                .Where(b => b.CategoryId == 1)
                .Join(Library.Categories,
                      book => book.CategoryId,
                      category => category.Id,
                      (book, category) => new {
                          book.PublishedYear,
                          book.Title
                      })
                .GroupBy(b => b.PublishedYear)
                .OrderBy(c => c.Key);

            foreach (var group in books) {
                Console.WriteLine($"# {group.Key}");
                foreach (var book in group) {
                    Console.WriteLine($"   {book.Title}");
                }
            }
        }

        private static void Exercise1_8() {

        }

    }
}
