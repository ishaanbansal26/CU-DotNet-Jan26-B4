
using System.Runtime.InteropServices;

namespace Day21
{
    class StudentManager
    {
        Dictionary<string, StudentManager> studentInfo = new Dictionary<string, StudentManager>();

        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Gpa { get; set; }
        public int AttendanceScore { get; set; }
        public DateTime LastSemesterDate { get; set; }
        
        public void AddStudent(StudentManager student)
        {
            studentInfo[student.Id] = student;
        }

        public void GpaBoost()
        {
            foreach (var s in studentInfo.Values)
            {
                if (s.AttendanceScore > 90)
                    s.Gpa = s.Gpa + 0.2m;
            }
        }

        public void RemoveStudents()
        {
            DateTime fiveYearsOlder = DateTime.Today.AddYears(-5);
            foreach (var s in studentInfo.Values)
            {
                if (s.LastSemesterDate < fiveYearsOlder)
                    studentInfo.Remove(s.Id);
            } 
        }

        public StudentManager StudentSearch(string id)
        {
            foreach(var s in studentInfo.Values)
            {
                if(s.Id == id)
                    return studentInfo[s.Id];
            }
            return null;
        }

        public void DisplayInfo()
        {
            foreach (var s in studentInfo.Values)
            {
                Console.WriteLine($"{s.Id} {s.Name} {s.Gpa} {s.AttendanceScore} {s.LastSemesterDate}");
            }
        }
    }

    internal class Class2
    {


        static void Main(string[] args)
        {
            StudentManager studentManager = new StudentManager();
            studentManager.AddStudent(new StudentManager()
            {
                Id = "A1",
                Name = "Raj",
                AttendanceScore = 89,
                Gpa = 3.5m,
                LastSemesterDate = new DateTime(2024, 12, 06)
            });

            studentManager.AddStudent(new StudentManager()
            {
                Id = "B1",
                Name = "Taj",
                AttendanceScore = 95,
                Gpa = 1.5m,
                LastSemesterDate = new DateTime(2020, 12, 06)
            });

            studentManager.DisplayInfo();
            Console.WriteLine("---------------------");
            studentManager.GpaBoost();
            studentManager.DisplayInfo();
            Console.WriteLine("---------------------");
            studentManager.RemoveStudents();
            studentManager.DisplayInfo();
            Console.WriteLine("---------------------");
            StudentManager s1 = studentManager.StudentSearch("A1");
            if (s1 != null)
            {
                Console.WriteLine($"{s1.Id} {s1.Name} {s1.Gpa} {s1.AttendanceScore} {s1.LastSemesterDate}");
            }
            else
            {
                Console.WriteLine("Student Not found");
            }
            Console.WriteLine("---------------------");
            
        }
    }
}
