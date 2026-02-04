namespace Day25
{
    class Runner
    {
        public string Name { get; set; }
        public double DistanceRun { get; set; }
        public double TimeTaken { get; set; }
        public bool Completed { get; set; }
        
        public double Speed()
        {
            return DistanceRun / TimeTaken/60;
        }
        public double PerformanceScore()
        {
            if(Completed)
            {
                return DistanceRun/TimeTaken/60 * 1.2;
            }
            return DistanceRun / TimeTaken / 60;
        }

    }
    internal class practice
    {
        static void Main(string[] args)
        {
            try
            {
                string file = @"..\..\..\runners.csv";
                using (FileStream fs = new FileStream(file, FileMode.Create))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    string[] info =
                    {
                    "Usain Bolt, 10, 9.58, True",
                    "Carl Lewis, 10, 9.86, True",
                    "Novice Runner, 5, 20, False",
                    "Marathon Pro, 42.2, 180, True"

                };

                    foreach (var i in info)
                    {
                        sw.WriteLine(i);
                    }
                }

                string[] run = File.ReadAllLines(file);

                List<Runner> r = new List<Runner>();
                foreach(var o in run)
                {
                    string[] runner = o.Split(',');

                    Runner r1 = new Runner()
                    {
                        Name = runner[0],
                        DistanceRun = double.Parse(runner[1]),
                        TimeTaken = double.Parse(runner[2]),
                        Completed = bool.Parse(runner[3])
                    };
                    r1.Speed();
                    r1.PerformanceScore();
                    r.Add(r1);
                }
                var v = r.Where(r=>r.DistanceRun>5).ToList();
                var v1 = r.OrderByDescending(r=>r.TimeTaken).ToList();

                Console.WriteLine("Name\t\tDistance\t\tSpeed\t\tScore");
                Console.WriteLine("---------------------------------------------");

                foreach(var runner in r)
                {
                    Console.WriteLine($"{runner.Name} {runner.DistanceRun} {runner.Speed()} " +
                        $"{runner.TimeTaken}"); 
                }

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
