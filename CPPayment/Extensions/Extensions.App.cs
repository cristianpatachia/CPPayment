namespace CPPayment.Extensions;

public static partial class Extensions
{
    private const string Cors = "Cors";

    public static WebApplication SetCorsWhitelist(this WebApplication app)
    {
        var allowedCorsClient = GetCorsWhitelist(app.Configuration);
        if (allowedCorsClient.Count() > 0)
        {
            app.UseCors(options => options.WithOrigins(allowedCorsClient)
                                        .AllowAnyMethod()
                                        .AllowAnyHeader());
        }

        return app;
    }

    public static string[] GetCorsWhitelist(IConfiguration configuration)
    {
        var whitelist = new List<string>();
        var corsSection = configuration.GetSection(Cors);

        foreach (var client in corsSection.GetChildren().OrEmpty())
        {
            try
            {
                var origin = client.Value;
                if (origin is not null || !string.IsNullOrEmpty(origin))
                {
                    whitelist.Add(origin);
                }
            }
            catch
            {
            }
        }

        return [.. whitelist];
    }
}
