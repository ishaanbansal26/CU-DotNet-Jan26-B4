using System.Text;

namespace ConsoleApp1
{
    class Employee
    {
        public int bonus;
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public int Exp { get; set; }

        public Employee(int i,string name,decimal s,int e)
        {
            Id = i;
            Name=name;
            Salary = s;
            Exp = e;
        }

        public decimal CalculateAnnualSalary()
        {
            return Salary * 12;
        }
        public void Display()
        {
            Console.WriteLine($"{Id}{Name}{CalculateAnnualSalary()}{Exp}");
        }
    }

    class PermanentEmployee : Employee
    {
        public PermanentEmployee(int i,string name,decimal s,int e)
            :base(i,name,s,e)
        {
            
        }
        public new decimal CalculateAnnualSalary()
        {
            decimal hra = Salary * 0.2m;
            decimal spa = Salary * 0.1m;
            if (Exp >= 5)
                bonus = 50000;
            return Salary * 12 + hra + spa + bonus;
        }
    }
    internal class E02
    {
        static void Main(string[] args)
        {
            //List<Employee> e = new List<Employee>();
            //e.Add(new Employee(1, "RAJ", 765.7m, 5));
            //e.Add(new PermanentEmployee(1, "RAJ", 765.7m, 5));

            Dictionary<int, Employee> d = new Dictionary<int, Employee>();
            d.Add(1, new Employee(101, "RAJ", 765.7m, 5));
            d.Add(2, new PermanentEmployee(102, "RAJ", 765.7m, 5));

            PermanentEmployee p = d[2] as PermanentEmployee;
            Console.WriteLine(p.CalculateAnnualSalary());

            foreach (var v in d.Values)
            {
                Console.WriteLine(v.CalculateAnnualSalary()); 
            }
        }
    }
}
