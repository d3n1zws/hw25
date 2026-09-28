namespace ConsoleApp25.Exceptions;

public class OrderNotFoundException: Exception
{
    public OrderNotFoundException(string Message): base(Message)
    {
        
    }
}
