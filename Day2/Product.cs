using System;

struct Product
{
    // Define fields for product details
    public string Name; // Stores product name
    public decimal Price; // Stores product price
    public int Quantity; // Stores product quantity

    // Constructor to initialize the product fields
    public Product(string name, decimal price, int quantity)
    {
        // Assign the product name
        Name = name;
        Price = price;
        Quantity = quantity;
        // Assign the product price
        // Assign the product quantity
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Initialize the inventory
        int maxProducts = 100;
        Product[] products = new Product[maxProducts];
        int productCount = 0;
        // Maximum number of products
        // Array to store products
        // Counter to track added products

        while (true)
        {
            // Display menu options for user interaction
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. View Products");
            Console.WriteLine("3. Update Product");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine(); // Read user choice

            switch (choice)
            {
                case "1":
                    // Add a new product
                    if (productCount < maxProducts)
                    {
                        Console.Write("Enter product name: ");
                        string name = Console.ReadLine(); // Get product name
                        Console.Write("Enter product price: ");
                        decimal price = Convert.ToDecimal(Console.ReadLine()); // Get and convert price
                        Console.Write("Enter product quantity: ");
                        int quantity = Convert.ToInt32(Console.ReadLine()); // Get and convert quantity
                        products[productCount] = new Product(name, price, quantity); // Add product
                        productCount++; // Increment product count
                        Console.WriteLine("Product added successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Inventory is full!"); // Show error if full
                    }
                    break;
                case "2":
                    // View all products
                    for (int i = 0; i < productCount; i++)
                    {
                        Console.WriteLine($"Name: {products[i].Name}, Price: {products[i].Price:F1}, Quantity: {products[i].Quantity}");
                    }
                    break;
                case "3":
                    // Update an existing product
                    Console.Write("Enter product name to update: ");
                    string updateName = Console.ReadLine();
                    bool found = false;
                    for (int i = 0; i < productCount; i++)
                    {
                        if (products[i].Name.Equals(updateName, StringComparison.OrdinalIgnoreCase))
                        {
                            found = true; // Mark as found
                            Console.Write("Enter new price: ");
                            products[i].Price = Convert.ToDecimal(Console.ReadLine()); // Update price
                            Console.Write("Enter new quantity: ");
                            products[i].Quantity = Convert.ToInt32(Console.ReadLine()); // Update quantity
                            Console.WriteLine("Product updated successfully!");
                            break;
                        }
                    }
                    if (!found)
                    {
                        Console.WriteLine("Product not found!"); // Handle missing product
                    }
                    break;
                case "4":
                    // Exit the application
                    return;
                default:
                    Console.WriteLine("Invalid choice, please try again."); // Handle invalid input
                    break;
            }
        }
    }
}