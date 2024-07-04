using System;
using System.Collections.Generic;
using System.IO;

namespace Example2
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Grade { get; set; }

        public Student(int id, string name, int age, double grade)
        {
            Id = id;
            Name = name;
            Age = age;
            Grade = grade;
        }
    }

    class Program
    {
        static List<Student> ReadStudentsFromCSV(string filePath)
        {
            List<Student> students = new List<Student>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');

                    if (values.Length == 4 && int.TryParse(values[0], out int id)
                        && int.TryParse(values[2], out int age) && double.TryParse(values[3], out double grade))
                    {
                        students.Add(new Student(id, values[1].Trim(), age, grade));
                    }
                }
            }
            return students;
        }

        static void WriteStudentsToCSV(string filePath, List<Student> students)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Student student in students)
                {
                    writer.WriteLine($"{student.Id}, {student.Name}, {student.Age}, {student.Grade}");
                }
            }
        }

        static void Main()
        {
            string filePath = "students.csv";

            List<Student> studentList = new List<Student>
            {
                new Student(1, "Alice", 20, 8.5),
                new Student(2, "Bob", 21, 7.8),
                new Student(3, "Charlie", 19, 9.2)
            };

            WriteStudentsToCSV(filePath, studentList);
            Console.WriteLine("Students written to CSV.");

            List<Student> readStudents = ReadStudentsFromCSV(filePath);
            Console.WriteLine("\nStudents read from CSV:");
            foreach (var student in readStudents)
            {
                Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}, Grade: {student.Grade}");
            }
        }
    }
}
