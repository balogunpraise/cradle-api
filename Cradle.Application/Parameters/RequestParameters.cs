using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cradle.Application.Parameters
{
    public class RequestParameter
    {
        private readonly int _maxPageSize = 50;
        private static readonly int MinPageNumber = 1;
        private static readonly int DefaultPageSize = 10;

        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public RequestParameter()
        {
            PageNumber = MinPageNumber;
            PageSize = DefaultPageSize;
        }
        public RequestParameter(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < MinPageNumber ? MinPageNumber : pageNumber;
            PageSize = pageSize > _maxPageSize ? DefaultPageSize : pageSize;
        }

        public static RequestParameter Validate(int pageNumber, int pageSize)
        {
            return new(pageNumber, pageSize);
        }
    }
}
