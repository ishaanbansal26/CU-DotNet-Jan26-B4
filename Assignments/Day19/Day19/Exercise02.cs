namespace Day19
{
    abstract class UtilityBill
    {
        public int ConsumerId { get; set; }
        public string ConsumerName { get; set; }
        public decimal UnitsConsumed { get; set; }
        public decimal RatePerUnit { get; set; }

        protected UtilityBill(int id, string name, decimal units, decimal rate)
        {
            ConsumerId = id;
            ConsumerName = name;
            UnitsConsumed = units;
            RatePerUnit = rate;
        }

        public abstract decimal CalculateBillAmount();

        public virtual decimal CalculateTax(decimal billAmount)
        {
            return billAmount * 0.05m;
        }

        public virtual void PrintBill()
        {
            decimal amount = CalculateBillAmount();
            decimal tax = CalculateTax(amount);
            decimal total = amount + tax;

            Console.WriteLine($"Id = {ConsumerId} Name = {ConsumerName} totalunits = {UnitsConsumed} finalPayableAmount = {total}");
        }
    }

    class ElectricityBill : UtilityBill
    {
        public ElectricityBill(int id, string name, decimal units, decimal rate)
            : base(id, name, units, rate) { }

        public override decimal CalculateBillAmount()
        {
            decimal bill = UnitsConsumed * RatePerUnit;
            if (UnitsConsumed > 300)
            {
                bill += bill * 0.1m;
            }
            return bill;
        }

        public override decimal CalculateTax(decimal billAmount)
        {
            return billAmount * 0.05m;
        }
    }

    class WaterBill : UtilityBill
    {
        public WaterBill(int id, string name, decimal units, decimal rate)
            : base(id, name, units, rate) { }

        public override decimal CalculateBillAmount()
        {
            return UnitsConsumed * RatePerUnit;
        }

        public override decimal CalculateTax(decimal billAmount)
        {
            return billAmount * 0.02m;
        }
    }

    class GasBill : UtilityBill
    {
        public GasBill(int id, string name, decimal units, decimal rate)
            : base(id, name, units, rate) { }

        public override decimal CalculateBillAmount()
        {
            return UnitsConsumed * RatePerUnit + 150;
        }

        public override decimal CalculateTax(decimal billAmount)
        {
            return 0;
        }
    }

    internal class Exercise02
    {
        static void Main(string[] args)
        {
            UtilityBill[] u =
            {
                new ElectricityBill(1, "Raju", 50, 8.5m),
                new WaterBill(2, "lucky", 25, 7.5m),
                new GasBill(3, "Hihihihi", 35, 6.5m)
            };

            List<UtilityBill> utilitylist = new List<UtilityBill>();

            for (int i = 0; i < u.Length; i++)
            {
                utilitylist.Add(u[i]);
            }

            foreach (UtilityBill utility in utilitylist)
            {
                utility.PrintBill();
            }
        }
    }
}
