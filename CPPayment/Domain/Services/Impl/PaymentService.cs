using CPPayment.Domain.Context;
using CPPayment.Domain.Models.SqlViews;
using CPPayment.Domain.Services.Interfaces;

namespace CPPayment.Domain.Services.Impl;

public class PaymentService : Repository<Payment, int>, IPaymentService
{
    public PaymentService(AppDbContext dbContext)
        : base(dbContext)
    {
    }

    public override async Task<List<Payment>> GetAllAsync(bool isTracked = false)
    {
        return await base.GetAllAsync(isTracked);
    }

    public override async Task<Payment?> GetByIdAsync(int id)
    {
        return await base.GetByIdAsync(id);
    }

    public override async Task AddAsync(Payment entity)
    {
        await base.AddAsync(entity);
    }

    public override Task UpdateAsync(Payment entity)
    {
        return base.UpdateAsync(entity);
    }

    public override async Task DeleteAsync(Payment entity)
    {
        await base.DeleteAsync(entity);
    }
    
    public override async Task SaveChangesAsync()
    {
        await base.SaveChangesAsync();
    }
}