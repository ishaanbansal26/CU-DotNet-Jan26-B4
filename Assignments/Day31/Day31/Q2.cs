
namespace Day31
{
    class Employee
    {
        public int Id;
        public string Name;
        public string Dept;
        public double Salary;
        public DateTime JoinDate;
    }

    internal class Q2
    {
        static void Main(string[] args)
        {
            var employees = new List<Employee>
            {
                new Employee{Id=1, Name="Ravi", Dept="IT", Salary=80000, JoinDate=new DateTime(2019,1,10)},
                new Employee{Id=2, Name="Anita", Dept="HR", Salary=60000, JoinDate=new DateTime(2021,3,5)},
                new Employee{Id=3, Name="Suresh", Dept="IT", Salary=120000, JoinDate=new DateTime(2018,7,15)},
                new Employee{Id=4, Name="Meena", Dept="Finance", Salary=90000, JoinDate=new DateTime(2022,9,1)}
            };

            var highestAndLowest = employees.GroupBy(x => x.Dept).Select(x => new { Dept = x.Key, Highest = x.Max(x => x.Salary),
            Lowest = x.Min(x => x.Salary) });
            foreach(var v in highestAndLowest)
            {
                Console.WriteLine(v.Dept + "-" + v.Highest + "-" + v.Lowest);
            }
            Console.WriteLine();

            var countPerDeot = employees.GroupBy(x => x.Dept).Select(n=> new {Dept = n.Key, Count = n.Count()});
            foreach(var v in countPerDeot)
                Console.WriteLine(v.Dept +"-"+v.Count);
            Console.WriteLine();
            var employeesJoinedAfter2020 = employees.Where(x => x.JoinDate.Year > 2020);
            foreach(var v in employeesJoinedAfter2020)
            {
                Console.WriteLine(v.Name);
            }
            Console.WriteLine();
            var projectNameAndAnnualSalary = employees.Select(x => new { Name = x.Name, Salary = x.Salary * 12 });
            foreach (var v in projectNameAndAnnualSalary)
            {
                Console.WriteLine(v.Name + "-" + v.Salary);
            }
        }
    }
}
