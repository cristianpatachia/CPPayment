namespace CPPayment.Extensions;

public static partial class Extensions
{
    public static IEnumerable<T> OrEmpty<T>(this IEnumerable<T> source) where T : class
    {
        return source ?? Enumerable.Empty<T>();
    }
}
