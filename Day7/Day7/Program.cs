namespace Day7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine()!;
            string[] inputs = input.Split('|');
            string gateCode = inputs[0];
            char userInitial = char.Parse(inputs[1]);
            byte accessLevel = byte.Parse(inputs[2]);
            byte attempts = byte.Parse(inputs[4]);

            if (!bool.TryParse(inputs[3], out bool isActive))
                // used TryParse instead of parse becuase the program wil crash when user enter any other string other than true or false
                //out bool isActive basically stores that value from the TryParse
                // bool.TryParse basically converts the string value to the boolean
            {
                Console.WriteLine("INVALID ACCESS LOG");
                return;
            }
            if (gateCode.Length != 2 || !char.IsLetter(gateCode[0]) || !char.IsDigit(gateCode[1]))
                //the gateCode[0] is the first character and the gateCode[1] is the Second character
            {
                Console.WriteLine("INVALID ACCESS LOG");
                return;
            }

            if (!char.IsUpper(userInitial)) //check if the character is not uppercase
            {
                Console.WriteLine("INVALID ACCESS LOG");
                return;
            }

            if (accessLevel < 1 || accessLevel > 7)
            {
                Console.WriteLine("INVALID ACCESS LOG");
                return;
            }

            if (attempts > 200)
            {
                Console.WriteLine("INVALID ACCESS LOG");
                return;
            }

            //return; is for exiting the code


            //applying the business logic here
            if (isActive == false)
            {
                Console.WriteLine("ACCESS DENIED - INVALID USER");
            }
            else if (attempts > 100)
            {
                Console.WriteLine("ACCESS DENIED - TOO MANY USERS");
            }
            else if (accessLevel >= 5)
            {
                Console.WriteLine("ACCESS GRANTED - HIGH SECURITY");
            }
            else
            {
                Console.WriteLine("ACCESS GRANTED - STANDARD");
            }

            string status = ""; //i have made a new string variable as i have to provide the status in output
            if (attempts > 100)
            {
                status = "ACCESS DENIED - TOO MANY ATTEMPTS";
            }
            else
            {
                status = "ACCESS GRANTED";
            }

            Console.WriteLine($"{"Gate",-8}:{gateCode}");
            Console.WriteLine($"{"User",-8}:{userInitial}");
            Console.WriteLine($"{"Level",-8}:{accessLevel}");
            Console.WriteLine($"{"Attempts",-8}:{attempts}");
            Console.WriteLine($"{"status",-8}:{status}");
        }
    }
}
