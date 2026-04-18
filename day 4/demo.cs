using System;
using System.Collections.Generic;

// Customer class
class Customer
{
    public int CustomerId { get; set; }
    public string Name { get; set; }
}

// Order class
class Order
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public string Product { get; set; }
    public string Category { get; set; }
}

class Program
{
    static void Main()
    {
        // 1. List to store orders
        List<Order> orders = new List<Order>();

        // 2. Dictionary to map customer ID → customer
        Dictionary<int, Customer> customers = new Dictionary<int, Customer>();

        // 3. HashSet for unique categories
        HashSet<string> categories = new HashSet<string>();

        // 4. Queue for order processing (FIFO)
        Queue<Order> orderQueue = new Queue<Order>();

        // 5. Stack for order status history (LIFO)
        Stack<string> statusHistory = new Stack<string>();

        // -------------------------------
        // ADD CUSTOMERS
        customers.Add(1, new Customer { CustomerId = 1, Name = "Alice" });
        customers.Add(2, new Customer { CustomerId = 2, Name = "Bob" });

        // -------------------------------
        // ADD ORDERS
        Order o1 = new Order { OrderId = 101, CustomerId = 1, Product = "Laptop", Category = "Electronics" };
        Order o2 = new Order { OrderId = 102, CustomerId = 2, Product = "Shirt", Category = "Clothing" };

        orders.Add(o1);
        orders.Add(o2);

        // Add categories (ensures uniqueness)
        categories.Add(o1.Category);
        categories.Add(o2.Category);
        categories.Add("Electronics"); // duplicate ignored

        // Add to processing queue
        orderQueue.Enqueue(o1);
        orderQueue.Enqueue(o2);

        // -------------------------------
        // UPDATE ORDER
        o1.Product = "Gaming Laptop";

        // -------------------------------
        // REMOVE ORDER
        orders.Remove(o2);

        // -------------------------------
        // PROCESS ORDERS (FIFO)
        Console.WriteLine("Processing Orders:");
        while (orderQueue.Count > 0)
        {
            Order current = orderQueue.Dequeue();
            Console.WriteLine($"Processing Order ID: {current.OrderId}");

            // Track status
            statusHistory.Push($"Order {current.OrderId} - Placed");
            statusHistory.Push($"Order {current.OrderId} - Shipped");
            statusHistory.Push($"Order {current.OrderId} - Delivered");
        }

        // -------------------------------
        // DISPLAY STATUS HISTORY (LIFO)
        Console.WriteLine("\nOrder Status History:");
        while (statusHistory.Count > 0)
        {
            Console.WriteLine(statusHistory.Pop());
        }

        // -------------------------------
        // DISPLAY UNIQUE CATEGORIES
        Console.WriteLine("\nProduct Categories:");
        foreach (var cat in categories)
        {
            Console.WriteLine(cat);
        }
    }
}