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

            string category = string.Empty;
            if (!(Transaction.Contains("deposit") || Transaction.Contains("withdrawl") || Transaction.Contains("transfer")))
            {
                category = "NON-FINANCIAL TRANSACTION";
            }

            if(Transaction.Contains("deposit") || Transaction.Contains("withdrawl") || Transaction.Contains("transfer")
                && Transaction.Equals("cash deposit successful"))
            {
                category = "STANDARD TRANSACTION";
            }

            if(Transaction.Contains("deposit") || Transaction.Contains("withdrawl") || Transaction.Contains("transfer")
                && !Transaction.Equals("cash deposit successful"))
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
