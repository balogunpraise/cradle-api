using Microsoft.EntityFrameworkCore;

namespace Cradle.Application.Wrappers
{
    public class PagedList<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public List<T> List { get; set; }
        public bool HasNextPage => PageNumber * PageSize < TotalCount;
        public bool HasPreviousPage => PageSize > 1;

        private PagedList(List<T> list, int pageNumber, int pageSize, int totalCount)
        {
            List = list;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
        }

        public static async Task<PagedList<T>> ToPagedList(IQueryable<T> query, int pageNumber, int pageSize)
        {
            var totalCount = await query.CountAsync();
            var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new (items, pageNumber, pageSize , totalCount);
        }
    }
}
