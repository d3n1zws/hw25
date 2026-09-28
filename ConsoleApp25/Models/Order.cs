using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp25.Models;

using ConsoleApp25.Enums;
using ConsoleApp25.Interfaces;
using System.Xml.Linq;

public class Order : IEntity
{
    static int id = 0;
    public int Id { get; set; }
    public Customer Customer { get; set; }
    public List<OrderItem> Items = new List<OrderItem>();
    public decimal TotalPrice { get; set; }
    public OrderStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public Order(Customer customer, OrderStatus status)
    {
        Customer = customer;
        Status = status;
        CreatedAt = DateTime.Now;
        IsDeleted = false;
        Id = ++id;
    }
    public bool TryRemoveFromStock(Product product, int quantity, out decimal totalPrice)
    {
        OrderItem? item = Items.Find(x => x.Product == product && x.Quantity == quantity);
        if (item == null)
        {
            totalPrice = 0;
            return false;
        }
        totalPrice = item.TotalPrice;
        Items.Remove(item);
        return true;
    }
    public void ApplyDiscount(ref decimal price, decimal percentage)
    {
        List<OrderItem> items = Items.FindAll(x => x.UnitPrice == price);
        foreach (OrderItem item in items)
        {
            item.UnitPrice = (100 - percentage) * item.UnitPrice / 100;
        }
    }
    public string GetInfo()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Order Id: {Id}");
        if (Customer != null)
        {
            sb.AppendLine($"Customer: {Customer.FirstName} {Customer.LastName} (Id: {Customer.Id})");
        }
        sb.AppendLine($"Status: {Status}");
        sb.AppendLine($"Created At: {CreatedAt}");
        sb.AppendLine($"Is Deleted: {IsDeleted}");
        sb.AppendLine($"Total Price: {TotalPrice:C}");
        sb.AppendLine($"Items ({Items.Count}):");
        foreach (var item in Items)
        {
            sb.AppendLine($" - {item.Product?.Name} x{item.Quantity} @ {item.UnitPrice:C} = {item.TotalPrice:C}");
        }
        return sb.ToString();
    }
}
