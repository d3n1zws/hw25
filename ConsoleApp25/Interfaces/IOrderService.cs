using ConsoleApp25.Enums;
using ConsoleApp25.Models;
using System.Collections.Generic;

namespace ConsoleApp25.Interfaces;

public interface IOrderService
{
    Order CreateOrder(Customer customer, OrderStatus status);
    void AddProductToOrder(int orderId, Product product, int quantity, decimal unitPrice);
    void RemoveProductFromOrder(int orderId, Product product, int quantity, decimal unitPrice)
    void ConfirmOrder(int orderId);
    void CancelOrder(int orderId);
    Order GetOrder(int id);
    List<Order> GetCustomerOrders(int customerId);
}
