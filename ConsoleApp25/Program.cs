using System;
using System.Linq;
using ConsoleApp25.Models;
using ConsoleApp25.Enums;

class Program
{
    static void Main()
    {
        var productService = new ProductService();
        var orderService = new OrderService();
        var customers = new System.Collections.Generic.List<Customer>();

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("1. Add Customer");
            Console.WriteLine("2. Add Product");
            Console.WriteLine("3. Show Products");
            Console.WriteLine("4. Search Product");
            Console.WriteLine("5. Filter Products");
            Console.WriteLine("6. Create Order");
            Console.WriteLine("7. Add Product To Order");
            Console.WriteLine("8. Remove Product From Order");
            Console.WriteLine("9. Show Order");
            Console.WriteLine("10. Confirm Order");
            Console.WriteLine("11. Cancel Order");
            Console.WriteLine("12. Show Customer Orders");
            Console.WriteLine("13. Delete Product");
            Console.WriteLine("14. Restore Product");
            Console.WriteLine("15. Show Deleted Products");
            Console.WriteLine("16. Product Statistics");
            Console.WriteLine("17. Object Inspector");
            Console.WriteLine("18. Garbage Collection Test");
            Console.WriteLine("19. Sales Statistics");
            Console.WriteLine("20. Product Utilities");
            Console.WriteLine();
            Console.WriteLine("0. Exit");
            Console.Write("Select: ");
            var choice = Console.ReadLine();
            if (choice == "0") break;

            try
            {
                switch (choice)
                {
                    case "1": AddCustomer(customers); break;
                    case "2": AddProduct(productService); break;
                    case "3": ShowProducts(); break;
                    case "4": SearchProduct(productService); break;
                    case "5": FilterProducts(productService); break;
                    case "6": CreateOrder(orderService, customers); break;
                    case "7": AddProductToOrder(orderService); break;
                    case "8": RemoveProductFromOrder(orderService); break;
                    case "9": ShowOrder(orderService); break;
                    case "10": ConfirmOrder(orderService); break;
                    case "11": CancelOrder(orderService); break;
                    case "12": ShowCustomerOrders(orderService); break;
                    case "13": DeleteProduct(productService); break;
                    case "14": RestoreProduct(productService); break;
                    case "15": ShowDeletedProducts(productService); break;
                    case "16": ProductStatistics(productService); break;
                    case "17": ObjectInspector(productService, orderService, customers); break;
                    case "18": MemoryTest.Run(); break;
                    case "19": SalesStatisticsMenu(); break;
                    case "20": ProductUtilitiesMenu(); break;
                    default: Console.WriteLine("Invalid selection"); break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    static void AddCustomer(System.Collections.Generic.List<Customer> customers)
    {
        Console.Write("FirstName: "); var fn = Console.ReadLine() ?? "";
        Console.Write("LastName: "); var ln = Console.ReadLine() ?? "";
        Console.Write("Email: "); var em = Console.ReadLine() ?? "";
        Console.Write("Phone: "); var ph = Console.ReadLine() ?? "";
        var cust = new Customer(fn, ln, em, ph, false);
        customers.Add(cust);
        Console.WriteLine($"Customer added. Id: {cust.Id}");
    }

    static void AddProduct(ProductService productService)
    {
        Console.Write("Name: "); var name = Console.ReadLine() ?? "";
        Console.Write("Description: "); var desc = Console.ReadLine() ?? "";
        Console.Write("Price: "); var price = decimal.Parse(Console.ReadLine() ?? "0");
        Console.Write("Stock: "); var stock = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("Category: "); var cat = Console.ReadLine() ?? "";
        var prod = new Product(name, desc, price, stock, cat, false);
        productService.AddProduct(prod);
        Console.WriteLine("Product added.");
    }

    static void ShowProducts()
    {
        foreach (var p in ProductService.Products.Where(x => !x.IsDeleted)) p.GetProductInfo();
    }

    static void SearchProduct(ProductService productService)
    {
        Console.Write("Query: "); var q = Console.ReadLine() ?? "";
        var list = productService.SearchProducts(q);
        foreach (var p in list) p.GetProductInfo();
    }

    static void FilterProducts(ProductService productService)
    {
        Console.WriteLine("1. By price range\n2. By category");
        Console.Write("Select: "); var s = Console.ReadLine();
        if (s == "1")
        {
            Console.Write("min: "); var min = decimal.Parse(Console.ReadLine() ?? "0");
            Console.Write("max: "); var max = decimal.Parse(Console.ReadLine() ?? "0");
            foreach (var p in productService.GetProductsByPrice(min, max)) p.GetProductInfo();
        }
        else if (s == "2")
        {
            Console.Write("category: "); var cat = Console.ReadLine() ?? "";
            foreach (var p in productService.GetProductsByCategory(cat)) p.GetProductInfo();
        }
    }

    static void CreateOrder(OrderService orderService, System.Collections.Generic.List<Customer> customers)
    {
        Console.Write("Customer Id: "); var cid = int.Parse(Console.ReadLine() ?? "-1");
        var customer = customers.Find(x => x.Id == cid);
        if (customer == null) { Console.WriteLine("Customer not found"); return; }
        var order = orderService.CreateOrder(customer, OrderStatus.Pending);
        Console.WriteLine($"Order created. Id: {order.Id}");
    }

    static void AddProductToOrder(OrderService orderService)
    {
        Console.Write("Order Id: "); var oid = int.Parse(Console.ReadLine() ?? "-1");
        Console.Write("Product Id: "); var pid = int.Parse(Console.ReadLine() ?? "-1");
        var p = ProductService.Products.Find(x => x.Id == pid);
        if (p == null) { Console.WriteLine("Product not found"); return; }
        Console.Write("Quantity: "); var q = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("UnitPrice: "); var up = decimal.Parse(Console.ReadLine() ?? "0");
        orderService.AddProductToOrder(oid, p, q, up);
        Console.WriteLine("Product added to order.");
    }

    static void RemoveProductFromOrder(OrderService orderService)
    {
        Console.Write("Order Id: "); var oid = int.Parse(Console.ReadLine() ?? "-1");
        Console.Write("Product Id: "); var pid = int.Parse(Console.ReadLine() ?? "-1");
        var p = ProductService.Products.Find(x => x.Id == pid);
        if (p == null) { Console.WriteLine("Product not found"); return; }
        Console.Write("Quantity: "); var q = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("UnitPrice: "); var up = decimal.Parse(Console.ReadLine() ?? "0");
        orderService.RemoveProductFromOrder(oid, p, q, up);
        Console.WriteLine("Product removed from order.");
    }

    static void ShowOrder(OrderService orderService)
    {
        Console.Write("Order Id: "); var id = int.Parse(Console.ReadLine() ?? "-1");
        var o = orderService.GetOrder(id);
        Console.WriteLine(o.GetInfo());
    }

    static void ConfirmOrder(OrderService orderService)
    {
        Console.Write("Order Id: "); var id = int.Parse(Console.ReadLine() ?? "-1");
        orderService.ConfirmOrder(id);
        Console.WriteLine("Order confirmed.");
    }

    static void CancelOrder(OrderService orderService)
    {
        Console.Write("Order Id: "); var id = int.Parse(Console.ReadLine() ?? "-1");
        orderService.CancelOrder(id);
        Console.WriteLine("Order cancelled.");
    }

    static void ShowCustomerOrders(OrderService orderService)
    {
        Console.Write("Customer Id: "); var id = int.Parse(Console.ReadLine() ?? "-1");
        var list = orderService.GetCustomerOrders(id);
        foreach (var o in list) Console.WriteLine(o.GetInfo());
    }

    static void DeleteProduct(ProductService productService)
    {
        Console.Write("Product Id: "); var id = int.Parse(Console.ReadLine() ?? "-1");
        productService.RemoveProduct(id);
        Console.WriteLine("Product deleted.");
    }

    static void RestoreProduct(ProductService productService)
    {
        Console.Write("Product Id: "); var id = int.Parse(Console.ReadLine() ?? "-1");
        productService.RestoreProduct(id);
        Console.WriteLine("Product restored.");
    }

    static void ShowDeletedProducts(ProductService productService)
    {
        foreach (var p in ProductService.Products.Where(x => x.IsDeleted)) p.GetProductInfo();
    }

    static void ProductStatistics(ProductService productService)
    {
        Console.WriteLine($"Total products: {ProductService.Products.Count}");
        Console.WriteLine($"Available: {productService.GetAvailableProducts().Count}");
        Console.WriteLine($"Out of stock: {productService.GetOutOfStockProducts().Count}");
        try { Console.WriteLine("Most expensive:"); productService.GetMostExpensiveProduct().GetProductInfo(); } catch { }
        try { Console.WriteLine("Cheapest:"); productService.GetCheapestProduct().GetProductInfo(); } catch { }
        try { Console.WriteLine("Best selling:"); productService.GetBestSellingProduct().GetProductInfo(); } catch { }
    }

    static void ObjectInspector(ProductService productService, OrderService orderService, System.Collections.Generic.List<Customer> customers)
    {
        Console.WriteLine("Type: product/customer/order"); var type = Console.ReadLine();
        Console.Write("Id: "); var id = int.Parse(Console.ReadLine() ?? "-1");
        if (type == "product")
        {
            var p = ProductService.Products.Find(x => x.Id == id);
            if (p != null) p.GetProductInfo(); else Console.WriteLine("Not found");
        }
        else if (type == "customer")
        {
            var cu = customers.Find(x => x.Id == id);
            if (cu != null) Console.WriteLine($"Id:{cu.Id} Name:{cu.FullName} Email:{cu.Email}"); else Console.WriteLine("Not found");
        }
        else if (type == "order")
        {
            try { var o = orderService.GetOrder(id); Console.WriteLine(o.GetInfo()); } catch { Console.WriteLine("Not found"); }
        }
    }

    static void SalesStatisticsMenu()
    {
        var stats = new SalesStatisticsService(OrderService.orders);
        Console.WriteLine("1. Total Sales");
        Console.WriteLine("2. Total Orders");
        Console.WriteLine("3. Average Order Value");
        Console.WriteLine("4. Best Selling Product");
        Console.WriteLine("5. Best Customer");
        Console.WriteLine("6. Sales By Category");
        Console.WriteLine("7. Sales By Date");
        Console.Write("Select: "); var s = Console.ReadLine();
        switch (s)
        {
            case "1": Console.WriteLine($"Total Sales: {stats.GetTotalSales():C}"); break;
            case "2": Console.WriteLine($"Total Orders: {stats.GetTotalOrders()}"); break;
            case "3": Console.WriteLine($"Average Order Value: {stats.GetAverageOrderValue():C}"); break;
            case "4": var bp = stats.GetBestSellingProduct(); if (bp != null) bp.GetProductInfo(); else Console.WriteLine("No data"); break;
            case "5": var bc = stats.GetBestCustomer(); if (bc != null) Console.WriteLine($"Best Customer: {bc.FullName} (Id:{bc.Id})"); else Console.WriteLine("No data"); break;
            case "6": var byCat = stats.GetSalesByCategory(); foreach (var kv in byCat) Console.WriteLine($"{kv.Key}: {kv.Value:C}"); break;
            case "7": var byDate = stats.GetSalesByDate(); foreach (var kv in byDate) Console.WriteLine($"{kv.Key:d}: {kv.Value:C}"); break;
            default: Console.WriteLine("Invalid selection"); break;
        }
    }

    static void ProductUtilitiesMenu()
    {
        Console.Write("Product Id: "); var pid = int.Parse(Console.ReadLine() ?? "-1");
        var p = ProductService.Products.Find(x => x.Id == pid);
        if (p == null) { Console.WriteLine("Product not found"); return; }
        Console.WriteLine("1. IsInStock\n2. GetFinalPrice\n3. IsExpensive");
        Console.Write("Select: "); var s = Console.ReadLine();
        switch (s)
        {
            case "1": Console.WriteLine(ProductExtensions.IsInStock(p) ? "In stock" : "Not in stock"); break;
            case "2": Console.WriteLine($"Final price in orders: {ProductExtensions.GetFinalPrice(p):C}"); break;
            case "3": Console.Write("Threshold: "); var t = decimal.Parse(Console.ReadLine() ?? "0"); Console.WriteLine(p.IsExpensive(t) ? "Expensive" : "Not expensive"); break;
            default: Console.WriteLine("Invalid selection"); break;
        }
    }
}
