using CPPayment.Domain.Models.SqlViews;

namespace CPPayment.Domain.Services.Interfaces;

public interface IPaymentService : IRepository<Payment, int>
{
}
