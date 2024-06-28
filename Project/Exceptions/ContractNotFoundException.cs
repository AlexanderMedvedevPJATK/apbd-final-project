namespace Project.Exceptions;

public class ContractNotFoundException : Exception
{
    public ContractNotFoundException(string message) : base(message)
    {
    }
}