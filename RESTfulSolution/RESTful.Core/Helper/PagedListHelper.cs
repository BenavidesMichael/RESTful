using System;
using System.Collections.Generic;
using System.Linq;

namespace RESTful.Core.Helper
{
    public class PagedListHelper<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public int PageSize { get; set; }
        public int TotalItem { get; set; }


        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPage;


        public int? PreviousPageNumber => HasPreviousPage ? CurrentPage - 1 : null;
        public int? NextPageNumber => HasNextPage ? CurrentPage + 1 : null;


        public PagedListHelper(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalItem = count;
            CurrentPage = pageNumber;
            PageSize = pageSize;
            TotalPage = (int) Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }


        public static PagedListHelper<T> Create(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber -1) * pageSize)
                              .Take(pageSize)
                              .ToList();
            
            return new PagedListHelper<T>(items, count, pageNumber, pageSize);
        }

    }
}
