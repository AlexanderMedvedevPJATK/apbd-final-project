namespace Project.Exceptions;

public class ContractEndedException : Exception
{
    public ContractEndedException(string message) : base(message)
    {
    }
}