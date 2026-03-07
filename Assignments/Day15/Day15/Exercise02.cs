

using Microsoft.VisualBasic;

namespace Day15
{
    class Order
    {
        private DateTime date;
        private string status = string.Empty;

        private int orderId;

        public int OrderId
        {
            get { return orderId; }
        }
        private string customerName;

        public string CustomerName
        {
            get { return customerName; }
            set
            {
                if (string.IsNullOrEmpty(customerName))
                {
                    Console.WriteLine("Invalid Name");
                }
                customerName = value;
            }
        }
        private decimal totalAmount;

        public decimal TotalAmount
        {
            get { return totalAmount; }

        }

        public decimal AddItem(decimal price)
        {
            totalAmount += price;
            return totalAmount;
        }

        public void ApplyDiscount(decimal percentage)
        {
            decimal discountValue = 0;
            if (percentage > 1 && percentage < 30)
            {
                discountValue += totalAmount * (percentage / 100);
                totalAmount = totalAmount - discountValue;
            }


        }

        public string GetOrderSummary()
        {
            return $"Date {":",9} {date} \nOrder id {":",5} {orderId} \nCustomer {":",5} {customerName} \nTotal Amount {":"} {totalAmount}" +
            $"\nStatus {":",7} {status}";
        }

        public Order(int id, string name)
        {
            date = DateTime.Today;
            orderId = id;
            customerName = name;
            status = "NEW";
        }

    }

    internal class Exercise02
    {
        static void Main(string[] args)
        {
            Order order = new Order(101, "Rahul");

            order.AddItem(500);
            order.AddItem(300);
            order.ApplyDiscount(10);

            Console.WriteLine(order.GetOrderSummary());



        }
    }
}
