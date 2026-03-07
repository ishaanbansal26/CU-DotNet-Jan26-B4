namespace Day31
{
    class Transaction { public int Acc; public double Amount; public string Type; }
    internal class Q7
    {
        static void Main(string[] args)
        {
            var transactions = new List<Transaction>
            {
                new Transaction{Acc=101, Amount=5000, Type="Credit"},
                new Transaction{Acc=101, Amount=2000, Type="Debit"},
                new Transaction{Acc=102, Amount=10000, Type="Debit"}
            };

            var totalByAccount = transactions.GroupBy(g => g.Acc).Select(s => new { Account = s.Key, Amount = s.Sum(x => x.Amount) });
            Console.WriteLine("Total Amount per Account :");
            foreach(var v in totalByAccount)
            {
                Console.WriteLine(v.Account + " - "+ v.Amount);
            }
            Console.WriteLine();

            var highestAmount = transactions.GroupBy(g => g.Acc).Select(s => new { Acccount = s.Key, Highest = s.Max(m => m.Amount) });
            Console.WriteLine("Highest Amount per Account :");
            foreach (var v in highestAmount)
            {
                Console.WriteLine(v.Acccount + " - " + v.Highest);
            }
        }
    }
}
