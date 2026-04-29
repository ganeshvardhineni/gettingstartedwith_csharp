using System;

// Define PropertyDemo class
public class PropertyDemo
{
    // Define properties
    // Complete Step 1:............
    private string User { get; set; }
    public PropertyDemo(string user)
    {
        User = user;
    }
    public void Display()
    {
        Console.WriteLine("Private Value");
    }
}

// Define StaticDemo class
public class StaticDemo
{
    // Define static members
    // Complete Step 2:............
    public static int Number { get; set; }
    static StaticDemo()
    {
        Number = 10;
        Console.WriteLine("Static Constructor");
    }
    public static void NumChange()
    {
        Number = 20;
    }

}
// Define MathHelper static class
public static class MathHelper
{
    // Define static methods
    // Complete Step 3:............
    public static void Add(int a, int b)
    {
        Console.WriteLine("Static Method");
        Console.WriteLine(a + b);
    }
}

public class Program
{
    public static void Main()
    {
        // Demonstrate usage
        // Complete Step 4:............
        Console.WriteLine(5);

        PropertyDemo obj = new PropertyDemo("User1");
        obj.Display();

        Console.WriteLine(StaticDemo.Number);

        MathHelper.Add(10, 5);

        Console.WriteLine(5);
    }
}