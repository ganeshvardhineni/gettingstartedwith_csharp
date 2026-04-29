using System;

// Define delegate type
// Complete Step 1:............
public delegate int Operation(int a, int b);
class Program
{
    // Implement delegate methods
    // Complete Step 2:............
    public int Add(int a, int b)
    {
        return a + b;
    }

    public int Subtract(int a, int b)
    {
        return a - b;
    }

    public int Multiply(int a, int b)
    {
        return a * b;
    }

    public int Divide(int a, int b)
    {
        return a / b;
    }
    // Implement callback mechanism
    // Complete Step 3:............
    public static void PerformOperation(int a, int b, Operation op)
    {
        Console.WriteLine("Result: " + op(a, b));
    }
    static void Main(string[] args)
    {
        // Input handling
        // Complete Step 4:............
        Console.WriteLine("Enter first number:");
        int a = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter second number:");
        int b = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter operation (add, subtract, multiply, divide):");
        string choice = Console.ReadLine().ToLower();
        // Output handling
        // Complete Step 5:............
        Program p = new Program();
        Operation op = null;
        switch (choice)
        {
            case "add":
                op = p.Add;
                break;
            case "subtract":
                op = p.Subtract;
                break;
            case "multiply":
                op = p.Multiply;
                break;
            case "divide":
                if (b == 0) return;
                op = p.Divide;
                break;
            default:
                Console.WriteLine("Invalid operation");
                return;
        }
        if (op != null)
            PerformOperation(a, b, op);
    }
}