using System;

namespace ConsoleApp25.Exceptions;

public class OrderNotFoundException : Exception
{
    public OrderNotFoundException() : base("Order not found.") { }
    public OrderNotFoundException(string message) : base(message) { }
    public OrderNotFoundException(string message, Exception inner) : base(message, inner) { }
}
