using System.Text;

namespace Day44
{
    abstract class Subscriber : IComparable<Subscriber>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime JoinDate { get; set; }

        public abstract decimal CalculateMonthlyBill();

        public int CompareTo(Subscriber? other)
        {
            if (this.JoinDate == other.JoinDate)
                return this.Name.CompareTo(other.Name);
            return this.JoinDate.CompareTo(other.JoinDate);
        }

        public override bool Equals(object? obj)
        {
            var objId = obj as Subscriber;
            return this.Id.Equals(objId?.Id);
        }
        protected Subscriber(int id, string name, DateTime date)
        {
            Id = id;
            Name = name;
            JoinDate = date;
        }
    }

    class BusinessSubscriber : Subscriber
    {
        public decimal FixedRate { get; set; }
        public decimal TaxRate { get; set; }
        public BusinessSubscriber(int id, string name, DateTime joinDate,
            decimal fixedRate, decimal taxRate)
            : base(id, name, joinDate)
        {
            FixedRate = fixedRate;
            TaxRate = taxRate;
        }
        public override decimal CalculateMonthlyBill()
        {
            return FixedRate * (1+TaxRate);
        }
    }
    class ConsumerSubscriber : Subscriber
    {
        public decimal DataUsageGB { get; set; }
        public decimal PricePerGB { get; set; }
        public ConsumerSubscriber(int id, string name, DateTime joinDate,
            decimal dataUsageGB, decimal pricePerGB)
            : base(id, name, joinDate)
        {
            DataUsageGB = dataUsageGB;
            PricePerGB = pricePerGB;
        }
        public override decimal CalculateMonthlyBill()
        {
            return DataUsageGB * PricePerGB;
        }
    }
    class ReportGenerator
    {
        public static void PrintRevenueReporter(IEnumerable<Subscriber> subscribers)
        {
            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{"ID"} {"Name"} {"JoinDate"} {"MonthlyBill"}");
            foreach(var v in subscribers)
            {
                sb.AppendLine($"{v.Id} {v.Name} {v.JoinDate:dd-MM-yyyy} {v.CalculateMonthlyBill():N2}");
            }
            Console.WriteLine(sb.ToString());
        }
    }
    internal class SAASArch
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Subscriber> subscriber = new();
            subscriber.Add("abc@gmail.com", new BusinessSubscriber(1, "Raj", new DateTime(2026, 01, 01),700m,0.25m));
            subscriber.Add("def@gmail.com", new BusinessSubscriber(2, "Lucky", new DateTime(2026, 01,02),500m,0.22m));
            subscriber.Add("ghi@gmail.com", new ConsumerSubscriber(3, "Hero", new DateTime(2026, 01, 03),5m,90m));
            subscriber.Add("jkl@gmail.com", new ConsumerSubscriber(4, "Aman", new DateTime(2026, 01, 04),6m,80m));
            subscriber.Add("pqr@gmail.com", new BusinessSubscriber(5, "Rakesh", new DateTime(2026, 01, 05), 700m, 0.25m));

            Console.WriteLine(subscriber["abc@gmail.com"].Equals(subscriber["def@gmail.com"]));

            var sortByBill = subscriber.Values.OrderByDescending(x => x.CalculateMonthlyBill()).ToList();
            ReportGenerator.PrintRevenueReporter(sortByBill);
        }
    }
}
