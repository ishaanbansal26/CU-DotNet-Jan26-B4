using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Repositories
{
    internal class JsonStudentRepository : IStudentRepository
    {
        string file = @"../../../studentDetails.json";

        public List<Student> ReadFromFile()
        {
            if (!File.Exists(file))
                return new List<Student>();
            using (StreamReader sr = new StreamReader(file))
            {
                string data = sr.ReadToEnd();
                var result = JsonSerializer.Deserialize<List<Student>>(data);
                return result;
            }
        }

        public void WriteToFile(List<Student> students)
        {
            
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
            var serData = JsonSerializer.Serialize(students, options);

            using (StreamWriter sw = new StreamWriter(file, false))
            {
                sw.Write(serData);
            }
        }

        public void AddStudent(Student student)
        {
            var x = ReadFromFile();
            x.Add(student);
            WriteToFile(x);
        }

        public Student GetStudentById(int id)
        {
            var x = ReadFromFile();
            var find = x.Find(x => x.Id == id);
            return find;
        }

        public List<Student> GetStudents()
        {
            return ReadFromFile();
        }

        public void RemoveStudent(int id)
        {
            var x = ReadFromFile();
            var del = x.Find(x => x.Id == id);
            x.Remove(del);
            WriteToFile(x);
        }

        public void UpdateStudent(Student student)
        {
            var x = ReadFromFile();
            var find = x.Find(x => x.Id == student.Id);
            find.Name = student.Name;
            find.Grade = student.Grade;
            WriteToFile(x);
        }
    }
}
