
namespace Day31
{
    class Book
    {
        public string Title; public string Author; public string Genre; public int Year; public double Price; }



    internal class Q4
    {
        static void Main(string[] args)
        {
            var books = new List<Book>
            {
                new Book{Title="C# Basics", Author="John", Genre="Tech", Year=2018, Price=500},
                new Book{Title="Java Advanced", Author="Mike", Genre="Tech", Year=2016, Price=700},
                new Book{Title="History India", Author="Raj", Genre="History", Year=2019, Price=400}
            };

            var bookPublishedAfter2015 = books.Where(x => x.Year > 2015);
            foreach(var v in bookPublishedAfter2015)
            {
                Console.WriteLine(v.Title);
            }
            Console.WriteLine();
            var genreCount = books.GroupBy(x => x.Genre).Select(s => new { Genre = s.Key, Count = s.Count() });
            foreach(var v in genreCount)
            {
                Console.WriteLine(v.Genre+" - "+v.Count);
            }
            Console.WriteLine();
            var mostExpensiveByGenre = books.GroupBy(x => x.Genre).Select(s => new { Genre = s.Key, MostExpensive = s.Max(x => x.Price)}).ToList();
            foreach (var v in mostExpensiveByGenre)
            {
                Console.WriteLine(v.Genre + " - " + v.MostExpensive);
            }
            Console.WriteLine();
            var distinctAuthor = books.Distinct();
            foreach(var v in distinctAuthor)
            {
                Console.WriteLine(v.Author);
            }
        }
    }
}
