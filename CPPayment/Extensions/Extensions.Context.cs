using CPPayment.Domain.Context;
using Microsoft.EntityFrameworkCore;

namespace CPPayment.Extensions;

public static partial class Extensions
{
    public static IServiceCollection AddAppDbContext(
        this IServiceCollection services,
        WebApplicationBuilder builder)
    {
        var connectionString = GetConnection(builder);

        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

        return services;
    }

    public static string GetConnection(WebApplicationBuilder builder)
    {
        var environmentName = builder.Environment.EnvironmentName;

        return builder.Configuration.GetConnectionString(environmentName);
    }
}
