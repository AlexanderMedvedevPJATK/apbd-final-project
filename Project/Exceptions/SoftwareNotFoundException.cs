namespace Project.Exceptions;

public class SoftwareNotFoundException : Exception
{
    public SoftwareNotFoundException(string message) : base(message)
    {
    }
}