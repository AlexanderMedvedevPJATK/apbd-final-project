namespace Project.Exceptions;

public class ClientAlreadyHasContractException : Exception
{
    public ClientAlreadyHasContractException(string message) : base(message)
    {
    }
}