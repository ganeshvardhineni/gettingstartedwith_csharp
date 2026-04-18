using System;

class Student
{
    // Define properties
    public string Name;
    public int Age;
    public string Grade;
    // Complete Step 1:............

    // Define constructor
    public Student(string name, int age, string grade)
    {
        Name = name;
        Age = age;
        Grade = grade;
    }
    // Complete Step 2:............
}

class Program
{
    static void Main(string[] args)
    {
        // Prompt the user to enter student details
        Console.WriteLine("Enter student's name:");
        string name = Console.ReadLine();
        // Complete Step 3:............

        Console.WriteLine("Enter student's age:");
        int age = Convert.ToInt32(Console.ReadLine());
        // Complete Step 4:............

        Console.WriteLine("Enter student's grade:");
        string grade = Console.ReadLine();
        // Complete Step 5:............

        // Create an instance of the Student class
        Student s1 = new Student(name, age, grade);
        // Complete Step 6:............

        // Print student details
        Console.WriteLine("Student Name: " + s1.Name);
        Console.WriteLine("Student Age: " + s1.Age);
        Console.WriteLine("Student Grade: " + s1.Grade);
        // Complete Step 7:............
    }
}