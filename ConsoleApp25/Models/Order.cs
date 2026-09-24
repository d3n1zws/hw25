using System;
using System.Collections.Generic;

namespace ConsoleApp25.Models;

using ConsoleApp25.Enums;
using System.Xml.Linq;

public class Order
{
    static int id = 0;
    public int Id { get; set; }
    public Customer Customer { get; set; }
    public List<OrderItem> Items = new List<OrderItem>();
    public List<Product> Products = new List<Product>();
    public decimal TotalPrice { get; set; }
    public OrderStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public bool TryRemoveFromStock(string product, int quantity, out decimal totalPrice)
    {
        OrderItem? item = Items.Find(x => x.Product == product && x.Quantity == quantity && x.TotalPrice == totalPrice);
        if (item == null)
        {
            return false;
        }
        Items.Remove(item);
        return true;
    }
    public void ApplyDiscount(ref decimal price, decimal percentage)
    {
        List<OrderItem> items = Items.FindAll(x => x.UnitPrice == price);
        foreach (OrderItem item in items)
        {
            item.UnitPrice = (100 - percentage) * item.UnitPrice / 100;
            item.TotalPrice = (100 - percentage) * item.TotalPrice / 100;
        }
    }
    public Product SearchProduct(string s)
    {
        s = s.ToLower();
        Product? product = Products.Find(x => x.Name.ToLower() == s || x.Description.ToLower() == s || x.Category.ToLower() == s);
        if (product == null)
        {
            throw new Exception("Product tapilmadi:(");
        }
        return (Product)product;
    }
}
