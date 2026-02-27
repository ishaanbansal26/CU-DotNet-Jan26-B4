namespace Day27.Exercise01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string directory = @"..\..\..\";
                if (!Directory.Exists(directory))
                    throw new DirectoryNotFoundException("Directory not found.");
                string file = "journal.txt";
                
                string path = directory + file;
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    Console.WriteLine("Enter the things you did today : ");
                    do
                    {
                        string things = Console.ReadLine();
                        if (things.Equals("exit"))
                            break;
                        sw.WriteLine(things);
                    } while (true);
                }

                using (StreamReader sr = new StreamReader(path))
                {
                    do
                    {
                        string line = sr.ReadLine();
                        if (line == null)
                            break;
                        Console.WriteLine(line);
                    } while (true);
                }
            }
            catch(DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
