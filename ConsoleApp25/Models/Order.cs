using System;
using System.Collections.Generic;

namespace ConsoleApp25.Models;

public class Order
{
    static int id = 0;
    public int Id { get; set; }
    public Customer Customer { get; set; }
    public List<Product> Items { get; set; }
    public decimal TotalPrice { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsDeleted { get; set; }
}
