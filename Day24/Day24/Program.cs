using System.Collections;
using System.Collections.Generic;
namespace Day24
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Hashtable employeeTable = new Hashtable();
            employeeTable.Add(101, "Alice");
            employeeTable.Add(102, "Bob");
            employeeTable.Add(103, "Charlie");
            employeeTable.Add(104, "Diana");


            if (employeeTable[105] == null)
            {
                employeeTable.Add(105, "Edward");
            }
            else
            {
                Console.WriteLine("Id already Exists.");
            }
            string name = string.Empty;
            foreach (DictionaryEntry v in employeeTable)
            {
                if((int)v.Key==102)
                {
                    name=(string)v.Value;
                }
            }
            Console.WriteLine("The name is : "+name);

            foreach(DictionaryEntry v in employeeTable)
            {
                Console.WriteLine($"{v.Key} {v.Value}");
            }
            employeeTable.Remove(103);
            int count = employeeTable.Count;
            Console.WriteLine("The total no. of elements after deletion is " +
                count);
        }
    }
}
