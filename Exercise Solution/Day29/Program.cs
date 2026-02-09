namespace Day29
{
    interface ITimer
    {
        void SetTimer(int t);
    }

    interface ISmart
    {
        void ConnectWifi();

    }

    abstract class KitchenElectricalAppliance
    {
        public int ElectricalWatt { get; set; }
        public string ModelName { get; set; }
        public decimal Price { get; set; }

        public abstract void Cook();

        protected KitchenElectricalAppliance(int w, string name, decimal p)
        {
            ElectricalWatt = w;
            ModelName = name;
            Price = p;
        }
    }

    class MicrowaveOwen : KitchenElectricalAppliance, ITimer, ISmart
    {
        public MicrowaveOwen(int w, string name, decimal p) : base(w, name, p)
        {

        }
        public void ConnectWifi()
        {
            Console.WriteLine($"Microwave Owen {ModelName} is connected to the wifi.");
        }

        public override void Cook()
        {
            Console.WriteLine("Cooking in Microwave Owen");
        }
        public void SetTimer(int t)
        {
            Console.WriteLine($"Set the timer for {t} minutes");
        }
    }

    class Kettle : KitchenElectricalAppliance
    {
        public Kettle(int w, string name, decimal p) : base(w, name, p)
        {

        }
        public override void Cook()
        {
            Console.WriteLine("Cooking in kettle.");
        }
    }

    class Owen : KitchenElectricalAppliance
    {
        public Owen(int w, string name, decimal p) : base(w, name, p)
        {

        }
        public override void Cook()
        {
            Console.WriteLine("Cooking in Owen");
        }

        public void PreHeat(int time)
        {
            Console.WriteLine($"PreHeat the Owen for {time} minutes");
        }
    }

    class AirFryer : KitchenElectricalAppliance, ITimer, ISmart
    {
        public AirFryer(int w, string name, decimal p) : base(w, name, p)
        {

        }
        public void SetTimer(int t)
        {
            Console.WriteLine($"Set the timer for {t} minutes.");
        }
        public override void Cook()
        {
            Console.WriteLine("Cooking in AirFryer");
        }
        public void ConnectWifi()
        {
            Console.WriteLine($"AirFryer {ModelName} is connecter to the wifi.");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<KitchenElectricalAppliance> appliance = new List<KitchenElectricalAppliance>();
            appliance.Add(new MicrowaveOwen(76, "XY4567", 3456.78m));
            appliance.Add(new Kettle(26, "AB872", 886.78m));
            appliance.Add(new Owen(36, "PQ6789", 1156.98m));
            appliance.Add(new AirFryer(116, "AF5678", 4456.12m));


            foreach (var item in appliance)
            {
                item.Cook();
                if (item is ISmart)
                {
                    ISmart smart = item as ISmart;
                    smart.ConnectWifi();
                }
                if (item is ITimer time)
                {
                    time.SetTimer(5);
                }
            }


        }
    }
}
