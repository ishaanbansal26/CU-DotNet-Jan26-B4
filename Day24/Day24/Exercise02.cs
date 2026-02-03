
namespace Day24
{
    internal class Exercise02
    {
        static void Main(string[] args)
        {
            SortedDictionary<double,string> leaderboard 
                = new SortedDictionary<double,string>();
            leaderboard.Add(55.42, "SwiftRacer");
            leaderboard.Add(52.10, "SpeedDemon");
            leaderboard.Add(58.91, "SteadyEddie");
            leaderboard.Add(51.05, "TurboTom");

            foreach(var item in leaderboard)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("The fastest Time is :"+leaderboard.Keys.First());

            
            leaderboard.Remove(58.91);
            leaderboard.Add(54.00, "SteadyEddie");
            Console.WriteLine();
            Console.WriteLine("After the record updation");
            foreach (var item in leaderboard)
            {
                Console.WriteLine(item);
            }
        }
    }
}
