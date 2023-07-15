namespace Test.Helpers;

public static class PagingUtils
{
    public static IEnumerable<T> Page<T>(this IEnumerable<T> en, BaseQueryParameters? queryParameters)
    {
        if (queryParameters == null)
        {
            Console.WriteLine("Null query parameters");
            return en;
        }

        var page = queryParameters.Page - 1;
        return en.Skip(page * queryParameters.PageSize).Take(queryParameters.PageSize);
    }

    public static IQueryable<T> Page<T>(this IQueryable<T> en, BaseQueryParameters? queryParameters)
    {
        if (queryParameters == null)
        {
            Console.WriteLine("Null query parameters");
            return en;
        }

        var page = queryParameters.Page - 1;
        return en.Skip(page * queryParameters.PageSize).Take(queryParameters.PageSize);
    }
}