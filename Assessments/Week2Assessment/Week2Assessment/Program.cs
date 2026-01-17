namespace Week2Assessment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] policyHolderNames = new string[5];
            decimal[] annualPremiums = new decimal[5];
            
            GetHolderNames(policyHolderNames, annualPremiums);
            Console.WriteLine("Insurance Premium Summary");
            Console.WriteLine("----------------------------");
            Console.WriteLine($"{"Name"} {"Premium",11} {"Category",10}");
            Console.WriteLine("------------------------------------------------");
            string[] category = new string[5];
            PremiumCategory(annualPremiums, category);
            for (int i = 0; i < annualPremiums.Length; i++)
            {
                Console.WriteLine($"{policyHolderNames[i].ToUpper()} {annualPremiums[i],10:F2} {category[i],10}");
            }
            Console.WriteLine("------------------------------------------------");
            decimal totalValue = TotalPremiumAmount(annualPremiums);
            Console.WriteLine($"Total Premium {":",3} {totalValue:F2}");
            decimal avgValue = AveragePremium(annualPremiums);
            Console.WriteLine($"Average Premium {":"} {avgValue:F2}");
            decimal highestValue = HighestPremium(annualPremiums);
            Console.WriteLine($"Highest Premium {":"} {highestValue:F2}");
            decimal lowestValue = LowestPremium(annualPremiums);
            Console.WriteLine($"Lowest Premium {":",2} {lowestValue:F2}");
        }

        static void GetHolderNames(string[] policyHolderNames, decimal[] annualPremiums)
        {
            for (int i = 0; i < policyHolderNames.Length; i++)
            {
                Console.Write("Name :");
                policyHolderNames[i] = Console.ReadLine()!;
                while (policyHolderNames[i].Equals(""))
                {
                    Console.WriteLine("Enter the valid name :");
                    policyHolderNames[i] = Console.ReadLine()!;
                }
                Console.Write("Annual Premium Amount :");
                annualPremiums[i] = decimal.Parse(Console.ReadLine());
                               
                while (annualPremiums[i] < 0)
                {
                    Console.WriteLine("Enter the valid amount :");
                    annualPremiums[i] = decimal.Parse(Console.ReadLine()!);
                }
            }

        }


        static decimal TotalPremiumAmount(decimal[] annualPremiums)
        {
            decimal total = 0;
            for (int i = 0; i < annualPremiums.Length; i++)
            {
                total += annualPremiums[i];
            }
            return total;
        }

        static decimal AveragePremium(decimal[] annualPremiums)
        {
            decimal total = 0;
            for (int i = 0; i < annualPremiums.Length; i++)
            {
                total += annualPremiums[i];
            }
            decimal average = total / annualPremiums.Length;
            return average;
        }

        static decimal HighestPremium(decimal[] annualPremiums)
        {
            decimal highest = annualPremiums.Max();
            return highest;
        }

        static decimal LowestPremium(decimal[] annualPremiums)
        {
            decimal lowest = annualPremiums.Min();
            return lowest;
        }

        static void PremiumCategory(decimal[] annualPreminum, string[] category)
        {
            for (int i = 0; i < annualPreminum.Length; i++)
            {
                if (annualPreminum[i] < 10000)
                {
                    category[i] = "LOW";
                }
                else if (annualPreminum[i] <= 25000)
                {
                    category[i] = "MEDIUM";
                }
                else
                {
                    category[i] = "HIGH";
                }
            }
        }
    }
}
