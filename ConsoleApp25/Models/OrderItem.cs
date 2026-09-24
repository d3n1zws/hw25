using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp25.Models;

public class OrderItem
{
    public OrderItem(string product, int quantity, decimal unitPrice)
    {
        Product = product;
        Quantity = quantity;
        UnitPrice = unitPrice;
        TotalPrice = quantity * unitPrice;
    }

    public string Product { get; set; } = null!;

    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; } 


}