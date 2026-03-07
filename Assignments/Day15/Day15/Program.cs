using System.Security.Cryptography;

namespace Day15
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
        
        public Height(int feet, double inches)
        {
            Feet = feet;
            Inches = inches;
        }

        public Height(double inches)
        {
            Feet = (int)inches / 12;
            Inches = inches%12;
        }
        /*public Height AddHeights(Height h2)
        {
            int h = this.Feet + h2.Feet;
            double i = this.Inches+h2.Inches;
            if (i >= 12.0)
            {
                h++;
                i = i-12;
            }
            Height added = new Height(h, i);
            return added;
            //return $"{h} feet {i:F1} inches";
        }*/
        public static Height operator +(Height h1, Height h2)
        {
            int h = h1.Feet + h2.Feet;
            double i = h1.Inches + h2.Inches;
            if (i >= 12.0)
            {
                h++;
                i = i - 12;
            }
            Height added = new Height(h, i);
            return added;
            //return $"{h} feet {i:F1} inches";
        }
        public override string ToString()
        {
            return $"{Feet} feet {Inches:F1} inches";
        }



    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Height person1 = new Height(5, 6.5);

            Height person2 = new Height(5, 8.5);

            Height person3 = new Height(65.5);
            
            Console.WriteLine(person1);
            Console.WriteLine(person2);
            Console.WriteLine(person3);

           //Height value = person1.AddHeights(person2);
           Height value = person1+person2;
           Console.WriteLine(value);

        }
    }
}
