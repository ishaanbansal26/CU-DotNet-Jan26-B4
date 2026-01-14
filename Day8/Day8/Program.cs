namespace Day8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("username|message :");
            string[] msg = Console.ReadLine()!.Split('|',StringSplitOptions.RemoveEmptyEntries|StringSplitOptions.TrimEntries);
            string userName = msg[0];
            string message = msg[1].ToLower();
            string std_message = "login successful";

            //Business Rules
            string status = string.Empty;
            if (message.Contains("successful") && message.Equals(std_message)){
                status = "LOGIN SUCCESS";
                //Console.WriteLine(status);
                
            }
            else if (message.Contains("successful")&& !message.Equals(std_message))
            {
                status = "LOGIN SUCCESS (CUSTOM MESSAGE)";
                //Console.WriteLine(status);

            }
            else
            {
                status = "LOGIN FAILED";
                //Console.WriteLine(status);
                
            }

            Console.WriteLine($"{"User"}{":",5} {userName}");
            Console.WriteLine($"{"Message"} {":",1} {message}");
            Console.WriteLine($"{"Status"}{":",3} {status}");

        }
    }
}