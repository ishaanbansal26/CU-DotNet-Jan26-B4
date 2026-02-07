namespace ConsoleApp1
{
    class Height
    {
        public int Feet { get; set; }
        public double Inches { get; set; }

        public Height()
        {
            Feet = 0;
            Inches = 0.0;
        }

        public Height(int f, double i)
        {
            Feet = f;
            Inches = i;
        }

        public string AddHeights(Height h2)
        {
            Feet = this.Feet + h2.Feet;
            Inches = this.Inches + h2.Inches;
            if(Inches>=12)
            {
                Feet++;
                Inches = Inches - 12;
            }
            return $"Height = {Feet} feet {Inches:F2} inches";
        }

        public override string ToString()
        {
            return $"Height = {Feet} feet {Inches:F2} inches";
        }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
              Height person1 = new Height(5,6.5);          
              Height person2 = new Height(5,7.6);
            Console.WriteLine(person1);
            Console.WriteLine(person2);
            Console.WriteLine(person1.AddHeights(person2));
        }
    }
}
