namespace Day14
{
    class Person
    {
        int id;
        public void GetId()
        {
            Console.WriteLine($"id : {id}");
        }

        public void SetId(int a)
        {
            id = a;
        }

        public string Name { get; set; }

        private string department;

        public string Department
        {
            get { return department; }
            set
            {
                string[] dep = { "Accounts", "Sales", "IT" };
                if (dep.Any(d => value.Contains(d)))
                {
                    department = value;
                }
                else
                {
                    Console.WriteLine("Enter the department again :");
                    department = Console.ReadLine()!;
                }
            }
        }

        private int salary;

        public int Salary
        {
            get { return salary; }
            set
            {
                if (value > 50000 && value < 90000)
                {
                    salary = value;
                }
                else
                {
                    Console.WriteLine("enter the salary again :");
                    salary = int.Parse(Console.ReadLine()!);
                }
            }


        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            p1.SetId(1);
            p1.GetId();
            p1.Name = "Ishaan";
            Console.WriteLine(p1.Name);
            p1.Department = "Marketing";
            Console.WriteLine(p1.Department);
            p1.Salary = 40000;
            Console.WriteLine(p1.Salary);
        }
    }
}
