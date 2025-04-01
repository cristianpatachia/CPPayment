using CPPayment.Domain.Context;
using Microsoft.EntityFrameworkCore;

namespace CPPayment.Extensions;

public static partial class Extensions
{
    public static IServiceCollection AddDbContext(
        this IServiceCollection services,
        WebApplicationBuilder builder)
    {
        var connectionString = GetConnectionString(builder);

        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

        return services;
    }

    public static string GetConnectionString(WebApplicationBuilder builder)
    {
        var environmentName = builder.Environment.EnvironmentName;

        return builder.Configuration.GetConnectionString(environmentName);
    }
}
