using System.ComponentModel;

namespace Day9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal[] arr = new decimal[7];
            Console.WriteLine("Enter the sale for each day:");
            decimal total = 0m;
            decimal avg = 0m;
            decimal highest = 0m;
            decimal lowest = 0m;
            decimal aboveAvg = 0m;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                arr[i] = decimal.Parse(Console.ReadLine()!);
                if (arr[i] < 0)
                {
                    return;
                }

                total += arr[i];
                avg = total / arr.GetLength(0);
                if(i==0)
                {
                    lowest = arr[i];
                    highest = arr[i];
                }
                else
                {
                    highest = Math.Max(highest, arr[i]);
                    lowest = Math.Min(arr[0], arr[i]);
                }
                     
                if(arr[i]>avg)
                {
                    aboveAvg++;
                }
            }

            string[] category = new string[7];

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 5000)
                    category[i] = "Low";
                else if (arr[i] > 5000 && arr[i] < 15000)
                    category[i] = "Medium";
                else
                    category[i] = "High";
            }


            Console.WriteLine($"Total sales {":",9} {total}");
            Console.WriteLine($"Average daily sales {":"} {avg:F2}");
            Console.WriteLine($"highest sale {":",8} {highest}");
            Console.WriteLine($"lowest sale {":",9} {lowest}");
            Console.WriteLine($"days above Average {":",2} {aboveAvg}");

            for (int i = 0; i <arr.GetLength(0); i++)
            {
                Console.WriteLine($"{"Day"}{i+1} {":"}{category[i]}");
            }

        }
    }
}
