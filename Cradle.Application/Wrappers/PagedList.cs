namespace Cradle.Application.Wrappers
{
    public class PagedList<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public List<T> List { get; set; }

        private PagedList(List<T> list, int pageNumber, int pageSize, int totalCount)
        {
            List = list;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
        }

        public static PagedList<T> ToPagedList(List<T> list, int pageNumber, int pageSize, int totalCount)
        {
            return new(list, pageNumber, pageSize, totalCount);
        }
    }
}
