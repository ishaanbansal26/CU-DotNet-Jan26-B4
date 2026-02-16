
namespace Day31
{
    class Product
    {
        public int Id;
        public string Name;
        public string Category;
        public double Price;
    }
    class Sale { public int ProductId; public int Qty; }

    internal class Q3
    {
        static void Main(string[] args)
        {
            var products = new List<Product>
            {
                new Product{Id=1, Name="Laptop", Category="Electronics", Price=50000},
                new Product{Id=2, Name="Phone", Category="Electronics", Price=20000},
                new Product{Id=3, Name="Table", Category="Furniture", Price=5000}
            };

            var sales = new List<Sale>
            {
                new Sale{ProductId=1, Qty=10},
                new Sale{ProductId=2, Qty=20}
            };

            var joinTable = products.Join(sales,
                p => p.Id,
                s => s.ProductId,
                (p,s) => new {p.Name, TotalRevenue = p.Price * s.Qty }
                ).GroupBy(x=>x.Name).Select(s=> new {Name = s.Key, Revenue = s.Sum(x=>x.TotalRevenue)}).ToList();

            foreach(var item in joinTable)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine("The Best selling product is :");
            var bestSellingProdcut = products.Join(sales,
                p => p.Id,
                s => s.ProductId,
                (p, s) => new { p.Name , quantity = s.Qty}).GroupBy(x=>x.Name).
                Select(s => new {BestProduct = s.Key, qty = s.Sum(m => m.quantity) }).OrderByDescending(x=>x.qty).Take(1);
             
            foreach(var v in bestSellingProdcut)
                Console.WriteLine(v);
            Console.WriteLine();
            var productWithZeroSale = products.GroupJoin(sales,
                products => products.Id,
                sales => sales.ProductId,
                (products, sales) => new { ProductName = products.Name, Quantity = sales.Sum(x => x.Qty)}).Where(w=>w.Quantity==0).OrderBy(x=>x.Quantity).Take(1);

            foreach(var v in productWithZeroSale)
            {
                Console.WriteLine(v);
            }
            
        }
    }
}
