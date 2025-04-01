using CPPayment.Domain.Context;
using CPPayment.Domain.Models.SqlViews;
using CPPayment.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CPPayment.Domain.Services.Impl;

public class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : SqlView
{
    protected readonly AppDbContext _dbContext;
    protected readonly DbSet<TEntity> _dbSet;
    protected bool _disposed;

    public Repository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<TEntity>();
    }

    public virtual async Task<List<TEntity>> GetAllAsync(bool isTracked = false) 
        => await (isTracked 
                    ? _dbSet
                    : _dbSet.AsNoTracking())
                .ToListAsync();

    public virtual async Task<TEntity?> GetByIdAsync(TKey id) => await _dbSet.FindAsync(id);
    
    public virtual async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity); 
        await SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(TEntity entity)
    {
        _dbSet.Update(entity);
        await SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(TEntity entity)
    {
        _dbSet.Remove(entity);
        await SaveChangesAsync();
    }

    public virtual async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed && disposing)
        {
            _dbContext?.Dispose();
        }
        _disposed = true;
    }

    ~Repository() => Dispose(false);
}
