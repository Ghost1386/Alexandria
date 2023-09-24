using Alexandria.DAL.Interfaces;
using Alexandria.Models;
using Alexandria.Models.Models;

namespace Alexandria.DAL.Repositorys;

public class PaymentRepository : IPaymentRepository
{
    private readonly ApplicationContext _applicationContext;

    public PaymentRepository(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public void CreatePayment(Payment payment)
    {
        _applicationContext.Payments.AddAsync(payment);
        _applicationContext.SaveChangesAsync();
    }
}