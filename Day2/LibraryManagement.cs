using System;

class Book
{
    // Define properties
    public string Title;
    public string Author;
    public int Year;
    // Complete Step 1:............

    // Define constructor
    public Book(string title,string author,int year)
    {
        Title = title;
        Author = author;
        Year = year;
    }
    // Complete Step 2:............
}

class Program
{
    static void Main(string[] args)
    {
        // Prompt the user to enter book details
        Console.WriteLine("Enter book's title:");
        string title = Console.ReadLine();
        // Complete Step 3:............

        Console.WriteLine("Enter book's author:");
        string author =Console.ReadLine();
        // Complete Step 4:............

        Console.WriteLine("Enter book's year:");
        int year = Convert.ToInt32(Console.ReadLine());
        // Complete Step 5:............

        // Create an instance of the Book class
        Book b = new Book(title, author, year);
    
        // Complete Step 6:............
        Console.WriteLine("Book Title: " + b.Title);
        Console.WriteLine("Book Author: " + b.Author);
        Console.WriteLine("Book Year: " + b.Year);

        // Print book details
        // Complete Step 7:............
    }
}