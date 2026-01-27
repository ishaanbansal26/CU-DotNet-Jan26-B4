
using System.Security.Cryptography.X509Certificates;

namespace Day18
{

    class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public decimal BasicSalary { get; set; }
        public int ExperienceInYears{ get; set; }

        public decimal annualSalary;
        public int bonus;

        public Employee(int id, string name, decimal salary, int years)
        {
            EmployeeId = id;
            EmployeeName = name;        
            BasicSalary = salary;
            ExperienceInYears = years;
        }

        public decimal CalculateAnnualSalary()
        {
            Console.WriteLine("Employee ");
            annualSalary = BasicSalary * 12;
            return annualSalary;    
        }

        public string DisplayEmployeeDetails()
        {
            return $"{EmployeeId} {EmployeeName} {annualSalary} {ExperienceInYears}";
        }
    }

    class PermanentEmployee : Employee
    {
        decimal houseRentAllowance;
        decimal specialAllowance;
        

        public PermanentEmployee(int id, string name, decimal salary, int years)
            : base(id, name, salary, years)
        {
            
        }

        public new decimal CalculateAnnualSalary()
        {
            houseRentAllowance = 0.2m * BasicSalary;
            specialAllowance = 0.1m * BasicSalary;

            if (ExperienceInYears >= 5)
            {
                bonus = 50000;
            }
            Console.WriteLine("Parent Employee");
            return BasicSalary * 12+ houseRentAllowance+ specialAllowance
                   + bonus;
        }
    }

    class ContactEmployee : Employee
    {
        public int ContactDurationInMonths { get; set; }

        
        public ContactEmployee(int id, string name, decimal salary, int years)
            : base(id, name, salary, years)
        {
            
        }

        public new decimal CalculateAnnualSalary()
        {
            annualSalary = BasicSalary * 12;
            if (ContactDurationInMonths >= 12)
            {
                bonus = 30000;
            }
            Console.WriteLine("Contact Employee");
            return annualSalary + bonus;
        }
    }

    class InternEmployee : Employee
    {
        public InternEmployee(int id, string name, decimal salary, int years)
            : base(id, name, salary, years)
        {
            annualSalary = BasicSalary * 12;
        }

        public new decimal CalculateAnnualSalary()
        {
            Console.WriteLine("Intern Employee");
            return annualSalary; 
        }
    }

    internal class Exercise02
    {
        static void Main(string[] args)
        {
            Employee emp1 = new Employee(1,"raju",7650,5);
            PermanentEmployee emp2 = new PermanentEmployee(1, "taju", 7650, 5);
            ContactEmployee emp3 = new ContactEmployee(1, "kaju", 7650, 5)
            {
                ContactDurationInMonths = 12,
            };

            Console.WriteLine(emp1.CalculateAnnualSalary());
            Console.WriteLine(emp2.CalculateAnnualSalary());
            Console.WriteLine(emp3.CalculateAnnualSalary());
            Console.WriteLine(emp1.DisplayEmployeeDetails());

        }
    }
}
