namespace Project.Exceptions;

public class DeletedClientException : Exception
{
    public DeletedClientException(string message) : base(message)
    {
    }
}