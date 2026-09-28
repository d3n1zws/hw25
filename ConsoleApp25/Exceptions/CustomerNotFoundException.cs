namespace ConsoleApp25.Exceptions;

public class CustomerNotFoundException : Exception
{
    public CustomerNotFoundException(string Message): base(Message)
    {
        
    }
}

