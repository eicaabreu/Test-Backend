using TEST.Application.SeedWork.Models;

namespace TEST.Application.SeedWork.Extensions
{
    public static class IQueryableExtensions
    {
        public static Task<PaginatedList<T>> PaginatedListAsync<T>(this IQueryable<T> queryable, IPaginationRequest paginatedRequest)
            => PaginatedList<T>.CreateAsync(queryable, paginatedRequest);
    }
}
