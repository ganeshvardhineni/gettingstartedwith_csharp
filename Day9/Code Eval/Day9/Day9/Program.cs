using System;

// Define your custom attribute class here
// Complete Step 1:............
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)]
public class CustomAttribute : Attribute
{
    public string Description { get; set; }
    public int Version { get; set; }

    public CustomAttribute(string description, int version)
    {
        Description = description;
        Version = version;
    }
}
// Example usage of the custom attribute
// Complete Step 2:............
[CustomAttribute("This is a sample class.", 1)]
class SampleClass
{
    [CustomAttribute("This is a sample property.", 3)]
    public string SampleProperty { get; set; }

    [CustomAttribute("This is a sample method.", 2)]
    public void SampleMethod() { }
}
class Program
{
    static void Main(string[] args)
    {
        // Implement scenarios to demonstrate attribute usage
        // Complete Step 3:............
        Type type = typeof(SampleClass);

        var classAttr = (CustomAttribute)Attribute.GetCustomAttribute(type, typeof(CustomAttribute));
        Console.WriteLine($"Class Description: {classAttr.Description}, Version: {classAttr.Version}");

        var method = type.GetMethod("SampleMethod");
        var methodAttr = (CustomAttribute)Attribute.GetCustomAttribute(method, typeof(CustomAttribute));
        Console.WriteLine($"Method Description: {methodAttr.Description}, Version: {methodAttr.Version}");

        var property = type.GetProperty("SampleProperty");
        var propAttr = (CustomAttribute)Attribute.GetCustomAttribute(property, typeof(CustomAttribute));
        Console.WriteLine($"Property Description: {propAttr.Description}, Version: {propAttr.Version}");
    }
}