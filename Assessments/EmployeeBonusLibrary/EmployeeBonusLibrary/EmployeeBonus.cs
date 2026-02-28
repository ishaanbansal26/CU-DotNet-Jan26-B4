namespace EmployeeBonusLibrary
{
    public class EmployeeBonus
    {
        public decimal BaseSalary { get; set; }
        public int PerformanceRating { get; set; }
        public int YearsOfExperience { get; set; }
        public decimal DepartmentMultiplier { get; set; }
        public double AttendancePercentage { get; set; }
        public decimal NetAnnualBonus
        {
            get
            {
                if (BaseSalary <= 0)
                    return 0m;

                decimal bonusPercentage = 0m;
                if (PerformanceRating == 5)
                    bonusPercentage = 0.25m;
                else if (PerformanceRating == 4)
                    bonusPercentage = 0.18m;
                else if (PerformanceRating == 3)
                    bonusPercentage = 0.12m;
                else if (PerformanceRating == 2)
                    bonusPercentage = 0.05m;
                else if (PerformanceRating == 1)
                    bonusPercentage = 0.00m;
                else
                    throw new InvalidOperationException("Invalid Performance Rating");

                decimal bonus = BaseSalary * bonusPercentage;

                if (YearsOfExperience > 10)
                    bonus += BaseSalary * 0.05m;
                else if (YearsOfExperience > 5)
                    bonus += BaseSalary * 0.03m;

                if (AttendancePercentage < 85)
                    bonus *= 0.80m;
                bonus *= DepartmentMultiplier;
                decimal maxBonus = BaseSalary * 0.40m;
                if (bonus > maxBonus)
                    bonus = maxBonus;
                decimal taxRate;

                if (bonus <= 150000m)
                    taxRate = 0.10m;
                else if (bonus <= 300000m)
                    taxRate = 0.20m;
                else
                    taxRate = 0.30m;

                decimal finalBonus = bonus - (bonus * taxRate);
                return Math.Round(finalBonus, 2);
            }
        }
    }
}