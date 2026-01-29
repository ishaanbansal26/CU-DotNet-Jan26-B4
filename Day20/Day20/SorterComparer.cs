namespace Day20
{
    class Flight : IComparable<Flight>
    {
        public string FlightNumber { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime DepartureTime { get; set; }
        public int CompareTo(Flight? other)
        {
            return this.Price.CompareTo(other?.Price);
        }
        public override string ToString()
        {
            return $"{FlightNumber} {Price} {Duration} {DepartureTime}";
        }
    }
    class DurationComparer : IComparer<Flight>
    {
        public int Compare(Flight? x, Flight? y)
        {
            return x!.Duration.CompareTo(y?.Duration);
        }
    }

    class DepartureComparer : IComparer<Flight>
    {
        public int Compare(Flight? x, Flight? y)
        {
            return x!.DepartureTime.CompareTo(y?.DepartureTime);
        }
    }
    internal class SorterComparer
    {
        static void Main(string[] args)
        {
            List<Flight> flights = new List<Flight>()
            {
                new Flight()
                {
                    FlightNumber = "764",
                    Price = 33000,
                    Duration = new TimeSpan(05,30,00),
                    DepartureTime = new DateTime(2026,05,10,05,30,00)
                },

                new Flight()
                {
                    FlightNumber = "762",
                    Price = 30000,
                    Duration = new TimeSpan(07,30,00),
                    DepartureTime = new DateTime(2026,05,13,07,30,00)
                },

                new Flight()
                {
                    FlightNumber = "760",
                    Price = 39000,
                    Duration = new TimeSpan(04,30,00),
                    DepartureTime = new DateTime(2026,05,11,06,30,00)
                }
            };

            Console.WriteLine("Economy View");
            flights.Sort();
            foreach (Flight flight in flights) 
            {
                Console.WriteLine(flight);
            }
            Console.WriteLine();

            Console.WriteLine("Business Runner View");
            flights.Sort(new DurationComparer());
            foreach (Flight flight in flights)
            {
                Console.WriteLine(flight);
            }
            Console.WriteLine();

            Console.WriteLine("Early Bird View");
            flights.Sort(new DepartureComparer());
            foreach (Flight flight in flights)
            {
                Console.WriteLine(flight);
            }

        }
    }
}
