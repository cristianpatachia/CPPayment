using Microsoft.EntityFrameworkCore;

namespace CPPayment.Domain.Context;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) 
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
