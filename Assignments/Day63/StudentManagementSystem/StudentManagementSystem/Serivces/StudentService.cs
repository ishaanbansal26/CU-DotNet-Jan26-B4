using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.Models;
using StudentManagementSystem.Repositories;

namespace StudentManagementSystem.Serivces
{
    internal class StudentService : IStudentSerivce
    {
        private IStudentRepository _repository { get; set; }

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }
        public List<Student> GetStudents()
        {
            return _repository.GetStudents();
        }

        public void AddStudent(Student student)
        {
            if(string.IsNullOrEmpty(student.Name) || (student.Name.Length<4 || student.Name.Length>20))
            {
                throw new ArgumentException("Invalid Name");
            }
            _repository.AddStudent(student);
        }

        public Student GetStudentById(int id)
        {
            var student = _repository.GetStudentById(id);
            if (student==null || student.Id != id)
                throw new ArgumentException("Invalid Id");
            return student;
        }

        public void RemoveStudent(int id)
        {
            var student = _repository.GetStudentById(id);
            if (student == null)
                throw new ArgumentException("Invalid Id");
            _repository.RemoveStudent(id);
        }

        public void UpdateStudent(Student student)
        {
            if (string.IsNullOrEmpty(student.Name) || student.Name.Length < 4)
                throw new ArgumentException("Invalid Updated Name");
            var x = new Student(student.Id, student.Name, student.Grade);
            _repository.UpdateStudent(x);
        }
    }
}
