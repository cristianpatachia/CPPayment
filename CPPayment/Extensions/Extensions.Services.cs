using CPPayment.Domain.Services.Impl;
using CPPayment.Domain.Services.Interfaces;

namespace CPPayment.Extensions;

public partial class Extensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

        services.AddScoped<IPaymentService, PaymentService>();

        return services;
    }
}
