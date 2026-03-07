using GreetingLibrary;
namespace GreetingApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your name : ");
            string name = Console.ReadLine()!;
            string result = GreetingHelper.GetGreeting(name);
            Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}
