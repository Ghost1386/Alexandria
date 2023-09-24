using Alexandria.Models.Models;

namespace Alexandria.DAL.Interfaces;

public interface IPaymentRepository
{
    void CreatePayment(Payment payment);
}