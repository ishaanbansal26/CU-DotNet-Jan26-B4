namespace Day25
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = string.Empty;
            ConsoleKeyInfo pass;
            Console.WriteLine("Enter the code : ");
            do
            {
                pass = Console.ReadKey(true);
                if (char.IsDigit(pass.KeyChar))
                {
                    s += pass.KeyChar;
                    Console.Write("*");
                }
                else if (pass.Key == ConsoleKey.Backspace && s.Length > 0)
                {
                    s = s.Substring(0, s.Length - 1);
                    Console.Write("\b \b");
                    // when the backspace key is pressed it take out the substring to remove the last
                    //character and also removes the *.
                }
                else if (pass.Key == ConsoleKey.Spacebar && s.Length > 0)
                {

                }
                else
                {
                    Console.WriteLine("\nOnly digits are allowed.");
                }
            }
            while (s.Length < 4);
            Console.WriteLine();
            Console.WriteLine("The code is : " + s);


        }
    }
}
