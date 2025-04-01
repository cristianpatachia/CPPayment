using CPPayment.Domain.Models.SqlViews;

namespace CPPayment.Domain.Services.Interfaces;

public interface IRepository<TEntity, TKey> : IDisposable
    where TEntity : SqlView
{
    Task<List<TEntity>> GetAllAsync(bool isTracked = false);

    Task<TEntity?> GetByIdAsync(TKey id);

    Task AddAsync(TEntity entity);

    Task UpdateAsync(TEntity entity);

    Task DeleteAsync(TEntity entity);

    Task SaveChangesAsync();
}
