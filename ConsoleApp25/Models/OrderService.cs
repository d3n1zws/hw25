using ConsoleApp25.Enums;
using ConsoleApp25.Exceptions;
using ConsoleApp25.Interfaces;

namespace ConsoleApp25.Models;

public class OrderService : IOrderService
{
    public static List<Order> orders = new List<Order>();
    public Order CreateOrder(Customer customer, OrderStatus status)
    {
        Order order = new Order(customer, status);
        orders.Add(order);
        return order;
    }

    public void AddProductToOrder(int orderId, Product product, int quantity, decimal unitPrice)
    {
        int index = orders.FindIndex(x => x.Id == orderId);
        if (index == -1)
        {
            throw new OrderNotFoundException("Order tapilmadi");
        }
        OrderItem orderItem = new OrderItem (product, quantity, unitPrice);
        orders[index].Items.Add(orderItem);
    }
    public void DeleteProduct(int orderId, int productId)
    {
        int index = orders.FindIndex(x => x.Id == orderId);
        if (index == -1)
        {
            throw new OrderNotFoundException("Order tapilmadi");
        }
        int index2 = orders[index].Items.FindIndex(x => x.Product.Id == productId);
        if (index2 == -1) 
        {
            throw new ProductNotFoundException("Product tapilmadi");
        }
        orders[index].Items[index2].Product.IsDeleted = true;
    }
    public void RemoveProductFromOrder(int orderId, Product product, int quantity, decimal unitPrice)
    {
        int index = orders.FindIndex(x => x.Id == orderId);
        if (index == -1)
        {
            throw new OrderNotFoundException("Order tapilmadi");
        }
        OrderItem orderItem = new OrderItem(product, quantity, unitPrice);
        OrderItem? orderItem1 = orders[index].Items.Find(x => x == orderItem);
        if (orderItem1 == null)
        {
            throw new ProductNotFoundException("Product tapilmadi");
        }
        orders[index].Items.Remove(orderItem);
    }

    public bool ConfirmOrder(int orderId)
    {
        int index = orders.FindIndex(x => x.Id == orderId);
        if (index == -1)
        {
            throw new OrderNotFoundException("Order tapilmadi");
        }
        orders[index].Status = OrderStatus.Confirmed;
        Order order = orders[index];
        CashPayment paymentService = new CashPayment();
        bool paymentResult = paymentService.Pay(order.TotalPrice);
        if (!paymentResult)
        {
            Console.WriteLine("Payment failed.");
            return false;
        }
        Console.WriteLine("Order confirmed.");
        return true;

    }

    public void CancelOrder(int orderId)
    {
        int index = orders.FindIndex(x => x.Id == orderId);
        if (index == -1)
        {
            throw new OrderNotFoundException("Order tapilmadi");
        }
        orders[index].Status = OrderStatus.Cancelled;
    }

    public Order GetOrder(int id)
    {
        Order? order = orders.Find(x => x.Id == id);
        if (order == null)
        {
            throw new OrderNotFoundException("Order tapilmadi");
        }
        return order;
    }

    public List<Order> GetCustomerOrders(int customerId)
    {
        List<Order> orders1 = orders.FindAll(x => x.Customer.Id == customerId);
        return orders1;
    }
}
