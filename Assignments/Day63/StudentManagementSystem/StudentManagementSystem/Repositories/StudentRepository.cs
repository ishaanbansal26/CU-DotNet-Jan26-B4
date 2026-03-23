using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Repositories
{
    internal class StudentRepository : IStudentRepository
    {
        private static List<Student> students = [];

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public Student GetStudentById(int id)
        {
            var x = students.Find(x => x.Id == id);
            return x;
        }

        public List<Student> GetStudents()
        {
            return students;
        }

        public void RemoveStudent(int id)
        {
            var x = students.Find(x => x.Id == id);
            students.Remove(x);
        }

        public void UpdateStudent(Student student)
        {
            var e = students.Find(x => x.Id == student.Id);
            e.Name = student.Name;
            e.Grade = student.Grade;
        }
    }
}
