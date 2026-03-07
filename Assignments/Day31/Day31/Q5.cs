
namespace Day31
{
    class Customer { public int Id; public string Name; public string City; }
    class Order { public int OrderId; public int CustomerId; public double Amount; }

    internal class Q5
    {
        static void Main(string[] args)
        {
            var customers = new List<Customer>
            {
             new Customer{Id=1, Name="Ajay", City="Delhi"},
            new Customer{Id=2, Name="Sunita", City="Mumbai"}
            };

            var orders = new List<Order>
            {
            new Order{OrderId=1, CustomerId=1, Amount=20000},
            new Order{OrderId=2, CustomerId=1, Amount=40000}
            };

            var totalAmountPerCustomer = customers.Join(orders,
                c => c.Id, o => o.CustomerId, (c, o) => new { c.Id, Amount = o.Amount })
                .GroupBy(x => x.Id).Select(s => new { CustomerId = s.Key, TotalAmount = s.Sum(k => k.Amount) });

            foreach (var v in totalAmountPerCustomer)
            {
                Console.WriteLine(v.CustomerId + "-" + v.TotalAmount);
            }
            Console.WriteLine();
            var customerWithNoOrder = customers.GroupJoin(orders,
                c => c.Id, o => o.CustomerId, (c, o) => new
                {
                    CustomersID = c.Id,
                    Order = o
                }).Where(x => x.Order.Count()==0).Select(s => s.CustomersID);

            foreach(var v in customerWithNoOrder)
            {
                Console.WriteLine("The customerID with zero orders is :"+v);
            }

            Console.WriteLine();
            var moreSpent = customers.Join(orders,
               c => c.Id, o => o.CustomerId, (c, o) => new { c.Id, Amount = o.Amount })
               .GroupBy(x => x.Id).Select(s => new { CustomerId = s.Key, Spent = s.Where(w=>w.Amount>50000)});

            foreach(var v in moreSpent)
            {
                Console.WriteLine("The customerId who spent more than 50000 is "+v.CustomerId);
            }


        }

    }
}
