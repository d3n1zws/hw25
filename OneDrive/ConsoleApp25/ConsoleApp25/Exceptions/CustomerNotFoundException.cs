using System;

namespace ConsoleApp25.Exceptions;

public class CustomerNotFoundException : Exception
{
    public CustomerNotFoundException() : base("Customer not found.") { }
    public CustomerNotFoundException(string message) : base(message) { }
    public CustomerNotFoundException(string message, Exception inner) : base(message, inner) { }
}
