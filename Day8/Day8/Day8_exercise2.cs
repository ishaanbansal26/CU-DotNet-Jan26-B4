using System.ComponentModel.Design;

namespace Day8
{
    internal class Day8_exercise2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TransactionId#AccountHolderName#TransactionNarration");
            string[] input = Console.ReadLine()!.Split('#',StringSplitOptions.RemoveEmptyEntries|StringSplitOptions.TrimEntries);
            string tId = input[0];
            string AccHolder = input[1];
            string Transaction = input[2].ToLower().Trim();
            string[] keywords = { "deposit", "withdrawl", "transfer" };

            string category = string.Empty;
            bool containsKeyword = keywords.Any(k=> Transaction.Contains(k)); 
            // i have created a bool varaiable which stores the true and false value of if any of the word is present in transaction
            // since we are checking for one keyword that is why we used the any if we wanted all words then we used All()

            bool found = false; // this is another method using the foreach - i wanted to learn the different ways that's why
            foreach (string word in keywords)
            {
                if (Transaction.Contains(word))
                {
                    found = true;
                    break;
                }
            }
               if (!found) 
                {
                    category = "NON FINANCIAL TRANSACTION";
                }

            if(containsKeyword && Transaction.Equals("cash deposit successful"))
            {
                category = "STANDARD TRANSACTION";
            }

            if (containsKeyword && !Transaction.Equals("cash deposit successful"))
            {
                category = "CUSTOM TRANSACTION";
            }

            Console.WriteLine($"Transaction ID {":"} {tId}");
            Console.WriteLine($"Account Holder {":"} {AccHolder}");
            Console.WriteLine($"Narration {":",6} {Transaction,3}");
            Console.WriteLine($"Category {":",7} {category}");
        }
        
    }
}
