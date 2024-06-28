namespace Project.Exceptions;

public class InvalidPaymentAmountException : Exception
{
    public InvalidPaymentAmountException(string message) : base(message)
    {
    }
}