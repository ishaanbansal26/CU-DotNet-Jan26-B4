namespace Day31
{
    class CartItem { public string Name; public string Category; public double Price; public int Qty; }
    internal class Q8
    {
        static void Main(string[] args)
        {
            var cart = new List<CartItem>
            {
                new CartItem{Name="TV", Category="Electronics", Price=30000, Qty=1},
                new CartItem{Name="Sofa", Category="Furniture", Price=15000, Qty=1}
            };

            var totalCartValue = cart.Sum(s => s.Price);
            Console.WriteLine(totalCartValue);
            Console.WriteLine();

            var groupByCategoryCost = cart.GroupBy(g => g.Category).Select(s => new { Category = s.Key, TotalCost = s.Sum(x => x.Price) });
            foreach(var v in groupByCategoryCost)
            {
                Console.WriteLine(v.Category +" - "+v.TotalCost);
            }
            Console.WriteLine();

            var discountForElectronics = cart.Where(x => x.Category == "Electronics").Select(s => new { cost = s.Price - s.Price * 0.1});
            Console.WriteLine("The price after 10% discount is :");
            foreach(var v in discountForElectronics)
            {
                Console.WriteLine(v.cost);
            }
            Console.WriteLine();

            var summary = cart.Select(s => new { ProductName = s.Name, TotalCost = s.Price * s.Qty });
            foreach(var v in summary)
            {
                Console.WriteLine(v.ProductName+" - "+v.TotalCost);
            }

        }
    }
}
