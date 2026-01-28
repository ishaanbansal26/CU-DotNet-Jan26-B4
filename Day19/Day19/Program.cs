namespace Day19
{
    abstract class Vehicle
    {
        public string ModelName { get; set; }

        protected Vehicle(string name)
        {
            ModelName = name;
        }
        public abstract void Move();
        public virtual string GetFuelStatus()
        {
            return "Fuel Level is stable.";
        }
    }

    class ElectricCar : Vehicle
    {
        public ElectricCar(string name) : base(name)
        {
            ModelName = name;
        }
        public override void Move()
        {
            Console.WriteLine($"{ModelName} is gliding silently on battery power");
        }

        public override string GetFuelStatus()
        {
            return $"{ModelName} battery is at 80%.";
        }
    }

    class HeavyTruck : Vehicle
    {
        public HeavyTruck(string name) : base(name)
        {
            ModelName = name;
        }
        public override void Move()
        {
            Console.WriteLine($"{ModelName} is hauling cargo with high-torque diesel power.");
        }
        public new string GetFuelStatus()
        {
            return "Fuel Level is stable.";
        }
    }

    class CargoPlane : Vehicle
    {
        public CargoPlane(string name) : base(name)
        {
            ModelName = name;
        }
        public override void Move()
        {
            Console.WriteLine($"{ModelName} is ascending to 30,000 feet.");
        }

        public override string GetFuelStatus()
        {
            return $"{base.GetFuelStatus()} Checking Jet fuel Reserves";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle[] v =
            {
                new ElectricCar("Tesla"),
                new HeavyTruck("TATA"),
                new CargoPlane("747")
            };

            for (int i = 0; i < v.Length; i++)
            {
                v[i].Move();
                Console.WriteLine(v[i].GetFuelStatus());
            }
        }
    }
}
