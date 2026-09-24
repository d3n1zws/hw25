using System;

namespace ConsoleApp25.Models;

public class Product
{
    static int id = 0;

    public Product(string name, string description, decimal price, int stock, string category, bool isDeleted)
    {
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        Category = category;
        IsDeleted = isDeleted;
        Id = id++;
        CreatedAt = DateTime.Now;
    }

    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string Category { get; set; } = null!;
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public void GetProductInfo()
    {
        Console.WriteLine($"Id : {Id}, Name : {Name}, Description : {Description}, Price : {Price}, Stock : {Stock}, Category : {Category}, Is Deleted : {IsDeleted}, Created At : {CreatedAt}");
    }
    public decimal CalculateDiscount(int x)
    {
        return (100 - x) * Price / 100;
    }

}
