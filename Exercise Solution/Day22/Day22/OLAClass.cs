namespace Day22
{
    class OLADriver
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string VehicleNo { get; set; }

        List<Ride> Rides = new List<Ride>();

        public void AddRide(Ride ride)
        {
            Rides.Add(ride);
        }

        public override string ToString()
        {
            return $"DriverId = {id} DriverName = {Name} VehicleNo = {VehicleNo}";
        }

        public void DisplayRide()
        {
            foreach (Ride ride in Rides)
            {
                Console.WriteLine(ride);
            }
        }

        public void TotalFare()
        {
            decimal fare = 0;
            foreach (var v in Rides)
            {
                fare += v.Fare;
            }
            Console.WriteLine($"Total Fare = {fare:N2}");
        }

    }
    class Ride
    {
        public int RideId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public decimal Fare { get; set; }

        public override string ToString()
        {
            return $"RideId = {RideId} From = {From} To = {To} Fare = {Fare:N2}";
        }

    }
    internal class OLAClass
    {
        static void Main(string[] args)
        {
            List<OLADriver> drivers = new List<OLADriver>();
            {
                drivers.Add(new()
                {
                    id = 1,
                    Name = "BAC",
                    VehicleNo = "AT7890",

                });

                drivers.Add(new()
                {
                    id = 2,
                    Name = "XYZ",
                    VehicleNo = "XY9112"
                });

                drivers[0].AddRide(new Ride()
                {
                    RideId = 101,
                    From = "CHD",
                    To = "DL",
                    Fare = 6789
                });

                drivers[0].AddRide(new Ride()
                {
                    RideId = 102,
                    From = "Dl",
                    To = "JPR",
                    Fare = 8999
                });
                drivers[1].AddRide(new Ride()
                {
                    RideId = 103,
                    From = "Mumbai",
                    To = "DL",
                    Fare = 12789
                });
                drivers[1].AddRide(new Ride()
                {
                    RideId = 104,
                    From = "Chennai",
                    To = "DL",
                    Fare = 15789
                });
            }

            foreach (OLADriver driver in drivers)
            {
                Console.WriteLine(driver);
                driver.DisplayRide();
                driver.TotalFare();
                Console.WriteLine("-------------------");
            }


        }
    }
}
