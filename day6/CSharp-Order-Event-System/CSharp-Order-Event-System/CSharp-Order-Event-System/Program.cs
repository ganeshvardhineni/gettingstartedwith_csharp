using System;

class Order
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public double Amount { get; set; }

    public override string ToString() =>
        $"Order #{OrderId} | {CustomerName} | ₹{Amount:F2}";
}

delegate void OrderPlacedHandler(Order order);

class OrderProcessor
{
    public event OrderPlacedHandler OnOrderPlaced;

    public void PlaceOrder(Order order)
    {
        Console.WriteLine($"\nOrder placed: {order}");
        OnOrderPlaced?.Invoke(order);
    }
}

class EmailService
{
    public void SendEmail(Order order)
    {
        Console.WriteLine($"Email sent to {order.CustomerName} at {order.Email} — your order #{order.OrderId} for ₹{order.Amount:F2} is confirmed.");
    }
}

class SMSService
{
    public void SendSMS(Order order)
    {
        Console.WriteLine($"SMS sent to {order.Phone} — Hi {order.CustomerName}, order #{order.OrderId} placed successfully!");
    }
}

class LoggerService
{
    public void LogOrder(Order order)
    {
        Console.WriteLine($"[LOG {DateTime.Now:yyyy-MM-dd HH:mm:ss}] Order #{order.OrderId} by {order.CustomerName} for ₹{order.Amount:F2} recorded.");
    }
}

class InventoryService
{
    public void ReserveStock(Order order)
    {
        Console.WriteLine($"Inventory updated — stock reserved for order #{order.OrderId}.");
    }
}

class Program
{
    static void Main()
    {
        var processor = new OrderProcessor();
        var email = new EmailService();
        var sms = new SMSService();
        var logger = new LoggerService();
        var inventory = new InventoryService();

        processor.OnOrderPlaced += email.SendEmail;
        processor.OnOrderPlaced += sms.SendSMS;
        processor.OnOrderPlaced += logger.LogOrder;
        processor.OnOrderPlaced += inventory.ReserveStock;

        Console.WriteLine("=== Placing order #101 (all 4 subscribers active) ===");
        processor.PlaceOrder(new Order
        {
            OrderId = 101,
            CustomerName = "Ananya Sharma",
            Email = "ananya@example.com",
            Phone = "+91-9876543210",
            Amount = 2499.00
        });

        Console.WriteLine("\n=== Placing order #102 (all 4 subscribers active) ===");
        processor.PlaceOrder(new Order
        {
            OrderId = 102,
            CustomerName = "Rohan Mehta",
            Email = "rohan@example.com",
            Phone = "+91-9123456789",
            Amount = 899.00
        });

        Console.WriteLine("\n=== Unsubscribing SMS service ===");
        processor.OnOrderPlaced -= sms.SendSMS;
        Console.WriteLine("SMS service unsubscribed.\n");

        Console.WriteLine("=== Placing order #103 (no SMS this time) ===");
        processor.PlaceOrder(new Order
        {
            OrderId = 103,
            CustomerName = "Priya Nair",
            Email = "priya@example.com",
            Phone = "+91-9988776655",
            Amount = 3299.00
        });

        Console.WriteLine("\n=== Unsubscribing inventory service ===");
        processor.OnOrderPlaced -= inventory.ReserveStock;
        Console.WriteLine("Inventory service unsubscribed.\n");

        Console.WriteLine("=== Placing order #104 (only email + logger) ===");
        processor.PlaceOrder(new Order
        {
            OrderId = 104,
            CustomerName = "Karan Patel",
            Email = "karan@example.com",
            Phone = "+91-9001122334",
            Amount = 1199.00
        });

        Console.WriteLine("\n=== Unsubscribing all services ===");
        processor.OnOrderPlaced -= email.SendEmail;
        processor.OnOrderPlaced -= logger.LogOrder;
        Console.WriteLine("All services unsubscribed.\n");

        Console.WriteLine("=== Placing order #105 (no subscribers — null-safe invoke handles this) ===");
        processor.PlaceOrder(new Order
        {
            OrderId = 105,
            CustomerName = "Sneha Reddy",
            Email = "sneha@example.com",
            Phone = "+91-9765432100",
            Amount = 599.00
        });
        Console.WriteLine("No notifications fired — no subscribers.");

        Console.WriteLine("\n=== Re-subscribing email and SMS for order #106 ===");
        processor.OnOrderPlaced += email.SendEmail;
        processor.OnOrderPlaced += sms.SendSMS;

        processor.PlaceOrder(new Order
        {
            OrderId = 106,
            CustomerName = "Arjun Verma",
            Email = "arjun@example.com",
            Phone = "+91-9654321098",
            Amount = 4599.00
        });

        Console.WriteLine("\n=== Using Action<Order> delegate directly (bonus) ===");

        Action<Order> notifyAll = o => Console.WriteLine($"Quick alert: order #{o.OrderId} placed for {o.CustomerName}.");
        notifyAll += o => Console.WriteLine($"Audit trail: ₹{o.Amount:F2} transaction recorded at {DateTime.Now:HH:mm:ss}.");

        notifyAll.Invoke(new Order
        {
            OrderId = 107,
            CustomerName = "Divya Singh",
            Email = "divya@example.com",
            Phone = "+91-9543210987",
            Amount = 750.00
        });
    }
}