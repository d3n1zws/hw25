using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
namespace ConsoleApp25.Models;

public static class JsonOperations
{
    public static void SaveOrders(List<Order> orders)
    {
        string json = JsonConvert.SerializeObject(orders);
        File.WriteAllText("C:\\Users\\LocUser\\OneDrive\\ConsoleApp25\\ConsoleApp25\\Files\\orders.json", json);
    }
    public static List<Order> LoadOrders()
    {
        string json = File.ReadAllText("C:\\Users\\LocUser\\OneDrive\\ConsoleApp25\\ConsoleApp25\\Files\\orders.json");

        List<Order> orders = JsonConvert.DeserializeObject<List<Order>>(json);
        return orders;
    }
    public static void SaveCustomers(List<Customer> customers)
    {
        string json = JsonConvert.SerializeObject(customers);
        File.WriteAllText("C:\\Users\\LocUser\\OneDrive\\ConsoleApp25\\ConsoleApp25\\Files\\customers.json", json);
    }
    public static List<Customer> LoadCustomers()
    {
        string json = File.ReadAllText("C:\\Users\\LocUser\\OneDrive\\ConsoleApp25\\ConsoleApp25\\Files\\customers.json");

        List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(json);
        return customers;
    }
}

