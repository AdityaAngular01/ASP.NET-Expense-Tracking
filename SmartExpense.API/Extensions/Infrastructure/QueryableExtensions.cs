using System.Linq.Expressions;
using SmartExpense.API.DTOs;
using SmartExpense.API.DTOs.Responses;

public static class QueryableExtensions
{
    public static async Task<PaginationDataDTO<T>> ToPagedResultAsync<T>(
        this IQueryable<T> query,
        QueryParams queryParams)
    {
        // Filtering (basic string search)
        if (!string.IsNullOrWhiteSpace(queryParams.Search))
        {
            var search = queryParams.Search.ToLower();

            query = query.Where(e =>
                e!.ToString()!.ToLower().Contains(search));
        }

        // Sorting (dynamic)
        if (!string.IsNullOrWhiteSpace(queryParams.SortBy))
        {
            query = ApplySorting(query, queryParams.SortBy, queryParams.IsDescending);
        }

        // Total count before pagination
        var totalItems = await Task.FromResult(query.Count());

        // Pagination
        var data = query
            .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
            .Take(queryParams.PageSize)
            .ToList();

        // Metadata
        var totalPages = (int)Math.Ceiling(totalItems / (double)queryParams.PageSize);

        var metadata = new PaginationMetadata
        {
            TotalItems = totalItems,
            TotalPages = totalPages,
            CurrentPage = queryParams.PageNumber,
            PageSize = queryParams.PageSize
        };

        return new PaginationDataDTO<T>
        {
            Data = data,
            Metadata = metadata
        };
    }

    // Dynamic Sorting
    private static IQueryable<T> ApplySorting<T>(
        IQueryable<T> source,
        string sortBy,
        bool isDescending)
    {
        var param = Expression.Parameter(typeof(T), "x");
        var property = Expression.PropertyOrField(param, sortBy);
        var lambda = Expression.Lambda(property, param);

        string methodName = isDescending ? "OrderByDescending" : "OrderBy";

        var result = typeof(Queryable).GetMethods()
            .First(method => method.Name == methodName
                             && method.GetParameters().Length == 2)
            .MakeGenericMethod(typeof(T), property.Type)
            .Invoke(null, new object[] { source, lambda });

        return (IQueryable<T>)result!;
    }
}