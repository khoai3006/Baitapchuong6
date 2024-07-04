using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string Category { get; set; }
}

class Program
{
    static List<Product> ReadProductsFromJSON(string filePath)
    {
        string jsonContent = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<Product>>(jsonContent);
    }

    static void WriteProductsToJSON(string filePath, List<Product> products)
    {
        string jsonContent = JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, jsonContent);
    }

    static void Main()
    {
        string filePath = "products.json";

        List<Product> productList = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 1000, Category = "Electronics" },
            new Product { Id = 2, Name = "Book", Price = 20, Category = "Books" },
            new Product { Id = 3, Name = "Headphones", Price = 50, Category = "Electronics" }
        };

        WriteProductsToJSON(filePath, productList);
        Console.WriteLine("Products written to JSON.");

        List<Product> readProducts = ReadProductsFromJSON(filePath);
        Console.WriteLine("\nProducts read from JSON:");
        foreach (var product in readProducts)
        {
            Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, Category: {product.Category}");
        }
    }
}
