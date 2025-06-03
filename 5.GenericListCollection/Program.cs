using System;
using System.Collections.Generic;

public class Student
{
    public int ID { get; set; }
    public string Name { get; set; }
}

public class Program
{
    static void Main(string[] args)
    {
        List<Student> students = new List<Student>();

        // Add students
        students.Add(new Student { ID = 1, Name = "Alice" });
        students.Add(new Student { ID = 2, Name = "Bob" });
        students.Add(new Student { ID = 3, Name = "Charlie" });

        // Display all students
        Console.WriteLine("All Students:");
        foreach (Student s in students)
        {
            Console.WriteLine($"ID: {s.ID}, Name: {s.Name}");
        }

        // Search by name (case-insensitive)
        Console.Write("\nEnter name to search: ");
        string searchName = Console.ReadLine();
        Student found = students.Find(s => s.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));
        if (found != null)
        {
            Console.WriteLine($"Found: ID={found.ID}, Name={found.Name}");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }

        // Remove by name (case-insensitive)
        Console.Write("\nEnter name to remove: ");
        string removeName = Console.ReadLine();
        Student toRemove = students.Find(s => s.Name.Equals(removeName, StringComparison.OrdinalIgnoreCase));
        if (toRemove != null)
        {
            students.Remove(toRemove);
            Console.WriteLine("Student removed.");
        }
        else
        {
            Console.WriteLine("Student not found to remove.");
        }

        // Updated list
        Console.WriteLine("\nUpdated List of Students:");
        foreach (Student s in students)
        {
            Console.WriteLine($"ID: {s.ID}, Name: {s.Name}");
        }

        // Total students
        Console.WriteLine($"\nTotal number of students: {students.Count}");
    }
}
