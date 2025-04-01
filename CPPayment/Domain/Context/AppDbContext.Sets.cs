using CPPayment.Domain.Models.SqlViews;
using Microsoft.EntityFrameworkCore;

namespace CPPayment.Domain.Context;

public partial class AppDbContext : DbContext
{
    public DbSet<Payment> Payments { get; set; }
}
