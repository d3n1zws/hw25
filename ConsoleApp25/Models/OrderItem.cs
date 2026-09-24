using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp25.Models;

public class OrderItem
{
    public Product Product { get; set; }

    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice => Quantity * UnitPrice;

}
//Product
//Quantity
//UnitPrice
//TotalPrice