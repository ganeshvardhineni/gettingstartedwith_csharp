using System;
using System.Collections.Generic;
class CustomCollection
{
    // Define internal data structure
    // Complete Step 1:............
    List<string> list = new List<string>();
    // Implement indexer
    // Complete Step 2:............
    public string this[int index]
    {
        get
        {
            if (index < 0 || index >= list.Count)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }
            return list[index];
        }

        set
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("Index cannot be negative");
            }
            if (index < list.Count)
            {
                list[index] = value;
            }
            else
            {
                while (list.Count <= index)
                {
                    list.Add(null);
                }
                list[index] = value;
            }
        }
    }
    // Define method to set elements
    // Complete Step 3:............

    // Define method to get elements
    // Complete Step 4:............
}

class Program
{
    static void Main(string[] args)
    {
        // Create instance of CustomCollection
        // Complete Step 7:............
        CustomCollection custom = new CustomCollection();

        // Loop to set and get values based on user input
        for (int i = 0; i < 3; i++)
        {
            // Prompt the user to set elements
            Console.WriteLine("Enter index to set:");
            // Complete Step 5:............
            int setIndex = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter value to set:");
            // Complete Step 6:............
            string value = Console.ReadLine();
            custom[setIndex] = value;
            // Prompt the user to get the elements
            Console.WriteLine("Enter index to get:");
            // Complete Step 8:............
            int getIndex = int.Parse(Console.ReadLine());
            string result = custom[getIndex];
            Console.WriteLine("Retrieved value: " + result);
        }
    }
}