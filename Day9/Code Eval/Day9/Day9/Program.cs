using System;
using System.IO;


public class Program
{
    public static void Main(string[] args)
    {
        // Implement exception handling
        // Complete the code below to demonstrate various aspects of exception handling
        try
        {
            if (args.Length > 0)
            {
                switch (args[0])
                {
                    case "IndexOutOfRangeException":
                        // Trigger IndexOutOfRangeException
                        throw new IndexOutOfRangeException();
                    case "DivideByZeroException":
                        // Trigger DivideByZeroException
                        throw new DivideByZeroException();
                    case "FileNotFoundException":
                        // Trigger FileNotFoundException
                        throw new FileNotFoundException();
                }
            }
        }
        catch (IndexOutOfRangeException e)
        {
            Console.WriteLine("Index out of range error: " + e.Message);
        }
        catch (DivideByZeroException e)
        {
            Console.WriteLine("Divide by zero error: " + e.Message);
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine("File not found error: " + e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("General error: " + e.Message);
        }

    }
}