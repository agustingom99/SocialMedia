﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialMedia_Core.CustomEntities
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage  => CurrentPage < TotalPages;
        public int? NextPageNumber => HasNextPage ? CurrentPage + 1 :(int?)null ;
        public int? PreviousPageNumber => HasPreviousPage ? CurrentPage -1 :(int?)null ;
        // donde count: cant recursos en page
        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            CurrentPage = pageNumber;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }

        public static PagedList<T> Create(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1)*pageSize).Take(pageSize).ToList(); // esto hace la paginación
           
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}