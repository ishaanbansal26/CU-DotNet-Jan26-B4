namespace Day31
{
    class Movie { public string Title; public string Genre; public double Rating; public int Year; }
    internal class Q6
    {
        static void Main(string[] args)
        {
            var movies = new List<Movie>
            {
            new Movie{Title="Inception", Genre="SciFi", Rating=9, Year=2010},
            new Movie{Title="Avatar", Genre="SciFi", Rating=8.5, Year=2009},
            new Movie{Title="Titanic", Genre="Drama", Rating=8, Year=1997}
            };

            var filterByRating = movies.Where(w => w.Rating > 8);
            foreach(var v in filterByRating)
            {
                Console.WriteLine(v.Title);
            }
            Console.WriteLine();

            var groupByGenre = movies.GroupBy(g => g.Genre).Select(s => new { Genre = s.Key, AvgRating = s.Average(a => a.Rating) });
            foreach(var v in groupByGenre)
            {
                Console.WriteLine(v.Genre+" - "+v.AvgRating);
            }
            Console.WriteLine();

            var latestMovie = movies.OrderByDescending(m => m.Year).Take(1);
            foreach(var v in latestMovie)
            {
                Console.WriteLine("The Latest Movie is :"+v.Title);
            }
            Console.WriteLine();

            var highestRated = movies.OrderByDescending(o => o.Rating).Take(5);
            foreach(var v in highestRated)
            {
                Console.WriteLine(v.Title + " - "+v.Rating);
            }
        }
    }
}
