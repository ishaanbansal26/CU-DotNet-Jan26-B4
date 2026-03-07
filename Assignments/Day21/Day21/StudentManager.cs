namespace Day21
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Marks { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name} {Marks}";
        }

    }

    class StudentManager
    {
        Dictionary<int, Student> studentDetails = new Dictionary<int, Student>();
        public bool AddStudent(Student student)
        {
            int id = student.Id;
            if (!studentDetails.ContainsKey(id))
            {
                studentDetails.Add(student.Id, student);
                return true;
            }
            return false;

        }

        public void DisplayAllStudents()
        {
            foreach (var v in studentDetails)
            {
                Console.WriteLine(v.Value);
            }
        }

        public bool UpdateStudent(int id, int marks)
        {
            Student foundStudent = SearchStudent(id);
            if (foundStudent != null)
            {
                foundStudent.Marks = marks;
                return true;
            }
            return false;
        }

        public bool DeleteStudent(int id)
        {
            return studentDetails.Remove(id);
        }
        public Student SearchStudent(int id)
        {

            //if(studentDetails.ContainsKey(id))
            //{
            //    return studentDetails[id]; 
            //}
            //return null;

            Student student = null;
            bool found = studentDetails.TryGetValue(id, out student);
            return student;
        }
    }
    internal class StudentManager
    {
        static void Main(string[] args)
        {
            StudentManager manager = new StudentManager();
            manager.AddStudent(new Student()
            {
                Id = 1,
                Name = "Raj",
                Marks = 98
            });

            manager.AddStudent(new Student()
            {
                Id = 2,
                Name = "Taj",
                Marks = 67
            });

            Console.WriteLine("Enter the number between 1 to 5.\n 1. Add Student \n 2. Display the Students \n 3. Update the student" +
                "\n 4. Delete the student \n 5. Search the student \n 6. 0 for exit.");
            int num = int.Parse(Console.ReadLine());

            int searchId = 1;

            while (num > 0 && num <= 5)
            {
                Student foundStudent = manager.SearchStudent(searchId);
                switch (num)
                {
                    case 1:
                        manager.AddStudent(new Student()
                        {
                            Id = 3,
                            Name = "Lucky",
                            Marks = 67
                        });
                        break;

                    case 2:
                        manager.DisplayAllStudents();
                        break;

                    case 3:
                        bool update = manager.UpdateStudent(2, 80);
                        if (update)
                        {
                            Console.WriteLine(manager.SearchStudent(2));
                        }
                        break;

                    case 4:
                        bool deleted = manager.DeleteStudent(searchId);
                        if (deleted)
                        {
                            Console.WriteLine($"Student Delete : {foundStudent}");
                        }
                        break;

                    case 5:
                        if (foundStudent == null)
                        {
                            Console.WriteLine($"{searchId} not found");
                        }
                        else
                        {
                            Console.WriteLine($"{foundStudent}");
                        }
                        break;
                }
                if (num == 0)
                    break;
                Console.WriteLine("Enter the number between 1 to 5 : ");
                num = int.Parse(Console.ReadLine());
            }

            //Console.WriteLine(manager.SearchStudent(3);
        }
    }
}
