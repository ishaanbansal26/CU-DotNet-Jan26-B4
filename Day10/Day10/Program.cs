using System.Globalization;

namespace Day10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal[] sales = new decimal[7];
            Console.WriteLine("Enter weekly sales for 7 days:");
            ReadWeeklySales(sales);

            Console.WriteLine("Weekly Sales Summary");
            Console.WriteLine("---------------------");
            decimal total = CalculateTotal(sales);
            Console.WriteLine($"Total Sales {":"} {total}");
            int days = 7;
            decimal average = CalculateAverage(total, days);
            Console.WriteLine($"Average Daily Sale {":"} {average:F2}");
            int day;
            decimal highest = FindHighestSale(sales, out day);
            Console.WriteLine($"Highest sale {":"} {highest:F2} (Day {day})");
            decimal lowest = FindLowestSale(sales, out day);
            Console.WriteLine($"Lowest sale {":"} {lowest:F2} (Day {day})");

            decimal discount = CalculateDiscount(total);
            Console.WriteLine($"Discount Applied {":"} {discount:F2}");
            decimal tax = CalculateTax(total);
            Console.WriteLine($"Tax Amount {":"} {tax:F2}");
            decimal finalPayable = CalculateFinalAmount(total, discount, tax);
            Console.WriteLine($"Final Payable {":"} {finalPayable:F2}");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Day wise Category:");
            string[] categories = new string[7];
            GenerateSalesCategory(sales, categories);
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine($"Day {i+1} {":"} {categories[i]}");
            }
        }


        static void ReadWeeklySales(decimal[] sales)
        {
            decimal[] input = new decimal[7];
            int index = 0;
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = decimal.Parse(Console.ReadLine()!);
                if (input[i] < 0)
                {
                    input[i] = Math.Abs(input[i]);
                }

                sales[index++] = input[i]; 
            }
        }

        static decimal CalculateTotal(decimal[] sales)
        {
            decimal total = 0;
            for(int i =0; i< sales.Length; i++)
            {
                total = total + sales[i];
            }

            return total;
        }

        static decimal CalculateAverage(decimal total, int days)
        {
            decimal avg = total / days;
            return avg;
        }

        static decimal FindHighestSale(decimal[] sales, out int day)
        {

            decimal highest = sales.Max();
            int idx = Array.IndexOf(sales, highest);
            day = idx + 1; // out basically sends the value to the caller
            // we dont have to print day as out will automatically sends its value
            return highest;
        }

        static decimal FindLowestSale(decimal[] sales, out int day)
        {
            decimal lowest = sales.Min();
            int idx1 = Array.IndexOf(sales,lowest);
            day = idx1 + 1;
            return lowest;
        }

        static decimal CalculateDiscount(decimal total)
        {
            decimal discount = 0;
            if(total>=50000)
            {
                //converting the discount % to decimal
                discount = total*0.10m;
            }
            else
            {
                discount = total * 0.05m;
            }
            return discount;
        }

        static decimal CalculateDiscount(decimal total,bool isFestivalWeek)
        {
            decimal discount = 0;
            if (total >= 50000 && isFestivalWeek)
            {
                //converting the discount % to decimal
                discount = total * 0.10m + total*0.05m;
            }
            else
            {
                discount = total * 0.05m;
            }
            return (discount);
        }

        static decimal CalculateTax(decimal amount)
        {
            decimal tax = amount * 0.18m; 
            return tax;
            //converting 18% to decimal 
        }

        static decimal CalculateFinalAmount(decimal total,decimal discount, decimal tax)
        {
            decimal finalAmount = total + tax - discount;
            return finalAmount;
        }

        static void GenerateSalesCategory(decimal[] sales, string[] categories)
        {
            for (int i = 0; i < sales.Length; i++)
            {
                if (sales[i] < 5000)
                {
                    categories[i] = "Low";
                }
                else if (sales[i] > 5000 && sales[i] < 15000)
                {
                    categories[i] = "Medium";
                }
                else
                {
                    categories[i] = "High";
                }
            }
        }
    }
}
