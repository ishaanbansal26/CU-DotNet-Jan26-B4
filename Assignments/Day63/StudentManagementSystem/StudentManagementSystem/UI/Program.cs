using StudentManagementSystem.Models;
using StudentManagementSystem.Repositories;
using StudentManagementSystem.Serivces;

namespace StudentManagementSystem.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine("List or Json (1/2)");
            int repoOption = int.Parse(Console.ReadLine());
            IStudentRepository repo = null;
            if (repoOption == 1)
                repo = new StudentRepository();
            if (repoOption == 2)
                repo = new JsonStudentRepository();

            IStudentSerivce service = new StudentService(repo);
            try
            {
                var student = GetStudent();
                service.AddStudent(student);
                var student2 = GetStudent();
                service.AddStudent(student2);

                Console.WriteLine();

                List<Student> students = service.GetStudents();
                DisplayStudents(students);
                Console.WriteLine();

                Console.WriteLine("Enter the id of student you want to find : ");
                int find = int.Parse(Console.ReadLine());
                Student StudentById = service.GetStudentById(find);
                Console.WriteLine(StudentById);

                Console.WriteLine();
                var updated = StudentUpdate();
                service.UpdateStudent(updated);
                Console.WriteLine();

                DisplayStudents(service.GetStudents());
                Console.WriteLine();

                Console.WriteLine("Enter the id you want to delete");
                int delete = int.Parse(Console.ReadLine());
                service.RemoveStudent(delete);
                Console.WriteLine();

                DisplayStudents(service.GetStudents());
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static Student GetStudent()
        {
            Console.WriteLine("Enter the Id");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the Grade between 1-100");
            int grade = int.Parse(Console.ReadLine());
            return new Student(id,name,grade);
        }

        public static void DisplayStudents(List<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }

        public static Student StudentUpdate()
        {
            Console.WriteLine("Enter Id to update");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter new grade");
            int grade = int.Parse(Console.ReadLine());
            return new Student(id, name, grade);
        }
    }
}
