using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ConsoleApp25.Enums;

namespace ConsoleApp25.Models;

using ConsoleApp25.Interfaces;

public class ProductService : IProductService
{
    public static List<Product> Products = new List<Product>();
    public void AddProduct(Product product)
    {
        Products.Add(product);
        Console.WriteLine("Prodcut elave olundu");
    }

    public List<Product> GetAllProducts()
    {
        return Products;
    }

    public Product GetProduct(int id)
    {
        Product? product = Products.Find(x =>  x.Id == id);
        if (product == null)
        {
            throw new Exception("Product tapilmadi");
        }
        return product;
    }

    public void RemoveProduct(int id)
    {
        Product? product = Products.Find(x => x.Id == id);
        if (product == null)
        {
            throw new Exception("Product tapilmadi");
        }
        Products.Remove(product);
    }

    public void RestoreProduct(int id)
    {
        int index = Products.FindIndex(x => x.Id == id);
        if (index == -1)
        {
            throw new Exception("Product tapilmadi");
        }
        Products[index].IsDeleted = false;
    }

    public List<Product> SearchProducts(string s)
    {
        s = s.ToLower();
        List<Product> products = Products.FindAll(x => x.Name.ToLower() == s || x.Description.ToLower() == s || x.Category.ToLower() == s);
        return products;
    }

    public Product GetMostExpensiveProduct()
    {
        if (Products == null || Products.Count == 0)
            throw new Exception("No products available");
        return Products.OrderByDescending(p => p.Price).First();
    }

    public Product GetCheapestProduct()
    {
        if (Products == null || Products.Count == 0)
            throw new Exception("No products available");
        return Products.OrderBy(p => p.Price).First();
    }

    public List<Product> GetAvailableProducts()
    {
        return Products.Where(p => !p.IsDeleted && p.Stock > 0).ToList();
    }

    public List<Product> GetOutOfStockProducts()
    {
        return Products.Where(p => !p.IsDeleted && p.Stock <= 0).ToList();
    }

    public List<Product> GetProductsByPrice(decimal min, decimal max)
    {
        if (min > max) throw new ArgumentException("min cannot be greater than max");
        return Products.Where(p => !p.IsDeleted && p.Price >= min && p.Price <= max).ToList();
    }

    public List<Product> GetProductsByCategory(string category)
    {
        if (string.IsNullOrWhiteSpace(category)) return new List<Product>();
        var cat = category.ToLower();
        return Products.Where(p => !p.IsDeleted && p.Category != null && p.Category.ToLower() == cat).ToList();
    }

    public Product GetBestSellingProduct()
    {
        if (Products == null || Products.Count == 0) throw new Exception("No products available");
        if (OrderService.orders == null || OrderService.orders.Count == 0) throw new Exception("No orders available");

        var sales = new Dictionary<int, int>(); // productId -> total quantity
        foreach (var order in OrderService.orders)
        {
            if (order == null) continue;
            if (order.IsDeleted) continue;
            if (order.Status != OrderStatus.Confirmed) continue;
            foreach (var item in order.Items)
            {
                if (item?.Product == null) continue;
                var id = item.Product.Id;
                if (!sales.ContainsKey(id)) sales[id] = 0;
                sales[id] += item.Quantity;
            }
        }

        if (sales.Count == 0) throw new Exception("No sales data available");
        var bestId = sales.OrderByDescending(kv => kv.Value).First().Key;
        var product = Products.Find(p => p.Id == bestId);
        if (product == null) throw new Exception("Best selling product not found in product list");
        return product;
    }

    public List<Order> GetCustomerOrders(int customerId)
    {
        if (OrderService.orders == null) return new List<Order>();
        return OrderService.orders.Where(o => o.Customer != null && o.Customer.Id == customerId).ToList();
    }
}
