using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Repositories
{
    internal interface IStudentRepository
    {
        void AddStudent(Student student);
        List<Student> GetStudents();

        Student GetStudentById(int id);

        void RemoveStudent(int id);

        void UpdateStudent(Student student);
    }
}
