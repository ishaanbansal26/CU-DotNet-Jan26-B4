
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

        public virtual decimal CalculateAnnualSalary()
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

        public override decimal CalculateAnnualSalary()
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

        public override decimal CalculateAnnualSalary()
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

        public override decimal CalculateAnnualSalary()
        {
            Console.WriteLine("Intern Employee");
            return annualSalary; 
        }
    }

    internal class Exercise02
    {
        static void Main(string[] args)
        {
            Employee[] e =
            {
                new PermanentEmployee(1,"abc",781,5),
                new ContactEmployee(1, "abc", 781, 5)
                {
                    ContactDurationInMonths = 12,
                },
                new InternEmployee(1,"abc",781,5)
            };

            for (int i = 0; i < e.Length; i++) 
            {
                Console.WriteLine(e[i].CalculateAnnualSalary());
            }

        }
    }
}
