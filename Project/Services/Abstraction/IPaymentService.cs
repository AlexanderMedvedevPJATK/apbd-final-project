namespace Project.Services.Abstraction;

public interface IPaymentService
{
    Task PayForContract(int idContract, double amount);
}