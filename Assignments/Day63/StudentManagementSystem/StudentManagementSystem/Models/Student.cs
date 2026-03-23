using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Models
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Range(1,100)]
        public int Grade { get; set; }
        public Student()
        {
            this.Id = Id;
            this.Name = Name;
            this.Grade = Grade;
        }

        public Student(int id, string name, int grade)
        {
            Id = id;
            Name = name;
            Grade = grade;
        }

        public override string ToString()
        {
            return $"{Id} {Name} {Grade}";
        }
    }
}
