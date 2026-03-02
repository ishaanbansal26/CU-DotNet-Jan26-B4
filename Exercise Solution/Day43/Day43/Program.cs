using System.Globalization;
using Day43;

namespace Day43
{
    interface IRiskAssessable
    {
        string GetRiskCategory();
    }
    interface IReportable
    {
        string GenerateReportLine();
    }

    class InvalidFinancialDataException : Exception
    {
        public InvalidFinancialDataException(string message) : base(message)
        {

        }
    }

    abstract class FinancialInstrument
    {
        public string InstrumentID { get; set; }
        public string Name { get; set; }

        private string _currency;
        public string Currency
        {
            get { return _currency; }
            set { _currency = value; }
        }

        private int _quantity;
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (value < 0)
                    throw new InvalidFinancialDataException("Quantity should not be less than zero");
                _quantity = value;
            }
        }

        private decimal _purchasePrice;
        public decimal PurchasePrice
        {
            get { return _purchasePrice; }
            set
            {
                if (value < 0)
                    throw new InvalidFinancialDataException("Price cannot be negative.");
                _purchasePrice = value;
            }
        }

        public decimal MarketPrice { get; set; }
        public DateOnly PurchaseDate { get; set; }

        public abstract decimal CalculateCurrentValue();

        public virtual string GetInstrumentSummary()
        {
            return $"{InstrumentID} - {Name} - {Currency}";
        }
    }

    class Equity : FinancialInstrument, IRiskAssessable, IReportable
    {
        public override decimal CalculateCurrentValue()
        {
            return Quantity * MarketPrice;
        }

        public string GetRiskCategory()
        {
            return "High";
        }

        public string GenerateReportLine()
        {
            return $"{InstrumentID} - Equity - {CalculateCurrentValue():C}";
        }
    }

    class Bond : FinancialInstrument, IRiskAssessable, IReportable
    {
        public override decimal CalculateCurrentValue()
        {
            return Quantity * MarketPrice;
        }

        public string GetRiskCategory()
        {
            return "Medium";
        }

        public string GenerateReportLine()
        {
            return $"{InstrumentID} - Bond - {CalculateCurrentValue():C}";
        }
    }
    class FixedDeposit : FinancialInstrument, IRiskAssessable
    {
        public override decimal CalculateCurrentValue()
        {
            return Quantity * MarketPrice;
        }

        public string GetRiskCategory()
        {
            return "Low";
        }
    }

    class MutualFund : FinancialInstrument, IRiskAssessable
    {
        public override decimal CalculateCurrentValue()
        {
            return Quantity * MarketPrice;
        }

        public string GetRiskCategory()
        {
            return "Medium";
        }
    }
    class Portfolio
    {
        public List<FinancialInstrument> instrument = new List<FinancialInstrument>();
        Dictionary<string, FinancialInstrument> dict = new Dictionary<string, FinancialInstrument>();

        public void AddInstrument(FinancialInstrument inst)
        {
            if (!dict.ContainsKey(inst.InstrumentID))
            {
                instrument.Add(inst);
                dict.Add(inst.InstrumentID, inst);
            }
        }
        public void RemoveInstrument(string id)
        {
            if (dict.ContainsKey(id))
            {
                instrument.Remove(dict[id]);
            }
        }
        public decimal GetTotalPortfolioValue()
        {
            return instrument.Sum(x => x.CalculateCurrentValue());
        }

        public FinancialInstrument GetInstrumentByID(string id)
        {
            if (dict.ContainsKey(id))
                return dict[id];
            return null;
        }
    }
    class Transaction
    {
        public int TransactionId { get; set; }
        public string InstrumentId { get; set; }
        public string Type { get; set; } 
        public int Units { get; set; }
        public DateOnly Date { get; set; }
        public static void ProcessTransactions(Portfolio portfolio)
        {
            Transaction[] transactions =
            {
            new Transaction { TransactionId = 1, InstrumentId = "EQ001", Type = "Buy", Units = 10, Date = DateOnly.FromDateTime(DateTime.Now) },
            new Transaction { TransactionId = 2, InstrumentId = "EQ001", Type = "Sell", Units = 5, Date = DateOnly.FromDateTime(DateTime.Now) }
            };

            List<Transaction> tList = transactions.ToList();

            foreach (var t in tList)
            {
                var instrument = portfolio.GetInstrumentByID(t.InstrumentId);

                if (instrument == null)
                {
                    Console.WriteLine("Instrument not found");
                    continue;
                }

                if (t.Type == "Buy")
                {
                    instrument.Quantity += t.Units;
                }
                else if (t.Type == "Sell")
                {
                    if (t.Units <= instrument.Quantity)
                        instrument.Quantity -= t.Units;
                    else
                        Console.WriteLine("Cannot sell more than owned");
                }
            }
        }
    }

    class ReportGenerator
    {
        public static void GenerateFileReport(Portfolio portfolio)
        {
            string fileName = @"../../../PortfolioReport_.txt";

            try
            {
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    sw.WriteLine("PORTFOLIO REPORT");
                    sw.WriteLine("Generated On: " + DateTime.Now);
                    sw.WriteLine();

                    var ordered = portfolio.instrument.OrderByDescending(i => i.CalculateCurrentValue());

                    foreach (var inst in ordered)
                    {
                        sw.WriteLine(
                            $"{inst.InstrumentID} | {inst.Name} | " +
                            $"Qty: {inst.Quantity} | " +
                            $"Current Value: {inst.CalculateCurrentValue().ToString("C")}"
                        );
                    }

                    sw.WriteLine();
                    var groups = portfolio.instrument.GroupBy(i => i.GetType().Name);

                    foreach (var group in groups)
                    {
                        decimal totalInvestment = group.Sum(i => i.Quantity * i.PurchasePrice);
                        decimal currentValue = group.Sum(i => i.CalculateCurrentValue());

                        sw.WriteLine();
                        sw.WriteLine($"Instrument Type: {group.Key}");
                        sw.WriteLine($"Total Investment: {totalInvestment.ToString("C")}");
                        sw.WriteLine($"Current Value: {currentValue.ToString("C")}");
                        sw.WriteLine($"Profit/Loss: {(currentValue - totalInvestment).ToString("C")}");
                    }

                    sw.WriteLine();
                    sw.WriteLine("Overall Portfolio Value: " + portfolio.GetTotalPortfolioValue().ToString("C"));
                }

                Console.WriteLine("File report generated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        Portfolio portfolio = new Portfolio();

        portfolio.AddInstrument(new Equity()
        {
            InstrumentID = "EQ001",
            Name = "INFY",
            Currency = "INR",
            Quantity = 100,
            PurchasePrice = 1500,
            MarketPrice = 1650,
            PurchaseDate = DateOnly.FromDateTime(DateTime.Now)
        });

        portfolio.AddInstrument(new Bond()
        {
            InstrumentID = "BD001",
            Name = "GovBond",
            Currency = "INR",
            Quantity = 50,
            PurchasePrice = 1000,
            MarketPrice = 1050,
            PurchaseDate = DateOnly.FromDateTime(DateTime.Now)
        });

        Transaction.ProcessTransactions(portfolio);
        ReportGenerator.GenerateFileReport(portfolio);
        Console.ReadLine();
    }
}


