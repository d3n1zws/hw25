using System;

namespace ConsoleApp25.Exceptions;

public class OutOfStockException : Exception
{
    public OutOfStockException() : base("Product is out of stock.") { }
    public OutOfStockException(string message) : base(message) { }
    public OutOfStockException(string message, Exception inner) : base(message, inner) { }
}
