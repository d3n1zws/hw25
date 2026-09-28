namespace ConsoleApp25.Exceptions;

public class OutOfStockException : Exception
{
    public OutOfStockException(string Message): base(Message)
    {
        
    }
}
