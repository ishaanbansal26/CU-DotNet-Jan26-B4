using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Serivces
{
    internal interface IStudentSerivce
    {
        void AddStudent(Student student);
        List<Student> GetStudents();

        Student GetStudentById(int id);
        void RemoveStudent(int id);

        void UpdateStudent(Student student);

    }
}
