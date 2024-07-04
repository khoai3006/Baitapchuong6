using System;

namespace Example1
{
    internal class Program
    {
        static readonly string FilePath = "data.txt";

        static void CreateFile(string filePath)
        {
            File.Create(filePath).Close();
        }

        static void WriteToFile(string filePath, string content)
        {
            File.WriteAllText(filePath, content);
        }

        static string ReadFromFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        static void AppendToFile(string filePath, string content)
        {
            File.AppendAllText(filePath, content);
        }

        static void DeleteFile(string filePath)
        {
            File.Delete(filePath);
        }

        static void Main()
        {
            CreateFile(FilePath);
            string initialContent = "Hello, this is initial content.";
            WriteToFile(FilePath, initialContent);

            Console.WriteLine("Content read from file:");
            Console.WriteLine(ReadFromFile(FilePath));

            string additionalContent = "\nThis is additional content.";
            AppendToFile(FilePath, additionalContent);

            Console.WriteLine("\nUpdated content read from file:");
            Console.WriteLine(ReadFromFile(FilePath));

            Console.ReadLine();
        }
    }
}
