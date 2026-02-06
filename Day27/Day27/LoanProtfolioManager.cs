using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;

namespace Day27
{
    public class Loan
    {
        public string ClientName { get; set; }
        public double Principal { get; set; }
        public double InterestRate { get; set; }

    }
    internal class LoanProtfolioManager
    {
        static void Main(string[] args)
        {
            string directory = @"..\..\..\";
            if (!Directory.Exists(directory))
                throw new DirectoryNotFoundException("Directory not found.");
            string file = "loanDetails.csv";

            string path = directory + file;
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                //string[] details =
                //{
                //"Raj,5500,5.5",
                //"Lucky,7500,5.5",
                //"Raj,9500,5.5"
                //};
                //foreach (string detail in details)
                //{
                //    sw.WriteLine(detail);
                //}
                //Console.WriteLine("Input : ClientName, Prinicpal, InterestRate");
                //Console.WriteLine("Enter the deatils in CSV.");
                //string s = Console.ReadLine();
                //sw.WriteLine(s);
            }
            Console.WriteLine("CLIENT           PRINICIPAL       INTEREST      RISKLEVEL");
            Console.WriteLine("---------------------------------------------------------");
            using (StreamReader sr = new StreamReader(path))
            {
                do
                {
                    try
                    {
                        string line = sr.ReadLine();
                        if (line == null)
                            break;
                        string[] ar = line.Split(",");
                        if (ar.Length < 3)
                            continue;
                        string name = ar[0];
                        double prinicipal = double.Parse(ar[1]);
                        double interest = double.Parse(ar[ar.Length - 1]);
                        double totalInterest = (prinicipal * interest) / 100;
                        string riskLevel = string.Empty;
                        if (interest > 10)
                            riskLevel = "HIGH";
                        else if (interest < 5)
                            riskLevel = "LOW";
                        else
                            riskLevel = "MEDIUM";

                        Loan l = new Loan()
                        {
                            ClientName = name,
                            Principal = prinicipal,
                            InterestRate = interest
                        };
                        Console.OutputEncoding = Encoding.Default;
                        Console.WriteLine($"{l.ClientName,-12}   {l.Principal,12:C2} {totalInterest,15:C2}  {riskLevel,12}");
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                } while (true);             
            }
        }
    }
}
