namespace ConsoleApp25.Exceptions;

public class ProductNotFoundException : Exception
{
    public ProductNotFoundException(string Message): base(Message)
    {
        
    }
}
