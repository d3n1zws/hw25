using System;

namespace ConsoleApp25.Models;

public class Product
{
    static int id = 0;
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string Category { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
}

//Id
//Name
//Description
//Price
//Stock
//Category
//IsDeleted
//CreatedAt
//Aşağıdakı metodları yaradın:
//GetProductInfo()
//CalculateDiscount()
