namespace Day31
{
    class Student
    {
        public int Id;
        public string Name;
        public string Class;
        public int Marks;
    }

    internal class Q1
    {
        static void Main(string[] args)
        {
            var students = new List<Student>
            {
            new Student{Id=1, Name="Amit", Class="10A", Marks=85},
            new Student{Id=2, Name="Neha", Class="10A", Marks=72},
            new Student{Id=3, Name="Rahul", Class="10B", Marks=90},
            new Student{Id=4, Name="Pooja", Class="10B", Marks=60},
            new Student{Id=5, Name="Kiran", Class="10A", Marks=95}
            };


            var topThreeByMarks = students.OrderByDescending(x => x.Marks).Take(3);
            foreach(var student in topThreeByMarks)
                Console.WriteLine(student.Name + student.Marks);
            Console.WriteLine();
            var groupByClass = students.GroupBy(x => x.Class)
                .Select(x => new { Class = x.Key, Name = x.Where(n=>n.Marks < x.Average(x=>x.Marks)).Select(s=>s.Name)});

            foreach (var v in groupByClass)
            {
                Console.WriteLine(v.Class);
                foreach(var name in v.Name)
                {
                    Console.WriteLine(name); 
                }
            }
            Console.WriteLine();
            var orderByClass = students.OrderBy(x => x.Class).ThenByDescending(x=>x.Marks);

            foreach (var v in orderByClass)
            {
                Console.WriteLine(v.Class +"-"+ v.Name +"-"+ v.Marks);
            }
                
            

        }
    }
}
