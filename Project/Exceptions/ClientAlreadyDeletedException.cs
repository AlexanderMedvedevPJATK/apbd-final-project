namespace Project.Exceptions;

public class ClientAlreadyDeletedException : Exception
{
    public ClientAlreadyDeletedException(string message) : base(message)
    {
    }
}