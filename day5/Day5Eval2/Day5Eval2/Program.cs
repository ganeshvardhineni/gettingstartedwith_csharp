using System;
// Define PropertyDemo class
public class PropertyDemo
{
    // Define properties
    // Complete Step 1:............
    private int num;
    public int Num
    {
        get
        {
            return num;
        }
        set
        {
            num = value;
        }
    }

    private string message;
    public string Message
    {
        get
        {
            return message;
        }
        set
        {
            message = value;
        }
    }

}
// Define StaticDemo class
public class StaticDemo
{
    // Define static members
    // Complete Step 2:............

    public static int number = 10;
    static StaticDemo()
    {
        Console.WriteLine("Static Constructor");
    }

    public static void mymethod()
    {
        Console.WriteLine("Static Method");
    }


}
// Define MathHelper static class
public static class MathHelper
{
    // Define static methods
    // Complete Step 3:............
    public static int addition(int num1, int num2)
    {
        int sum = num1 + num2;
        return sum;
    }
    public static int sub(int num1, int num2)
    {
        int sub = num1 - num2;
        return sub;
    }

}
public class Program
{
    public static void Main()
    {
        // Demonstrate usage
        // Complete Step 4:............
        PropertyDemo obj = new PropertyDemo();
        obj.Num = 5;
        obj.Message = "Private Value";
        Console.WriteLine(obj.Num);
        Console.WriteLine(obj.Message);

        Console.WriteLine(StaticDemo.number);
        StaticDemo.mymethod();

        int Sum = MathHelper.addition(StaticDemo.number, obj.Num);
        int Sub = MathHelper.sub(StaticDemo.number, obj.Num);
        Console.WriteLine(Sum);
        Console.WriteLine(Sub);
    }
}