using System;

namespace ConsoleApp25.Exceptions;

public class InvalidOrderException : Exception
{
    public InvalidOrderException() : base("Invalid order.") { }
    public InvalidOrderException(string message) : base(message) { }
    public InvalidOrderException(string message, Exception inner) : base(message, inner) { }
}
