using Homy.Application.DTOs.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homy.Application.Helpers
{
    public static class PaginationHelper
    {
        public static async Task<PagedResultDto<T>> CreatePagedResultAsync<T>(
           IQueryable<T> query,
           int pageNumber,
           int pageSize) where T : class
        {
            // التأكد من القيم
            pageNumber = pageNumber < 1 ? 1 : pageNumber;
            pageSize = pageSize < 1 ? 10 : pageSize;
            pageSize = pageSize > 100 ? 100 : pageSize; // حد أقصى 100 عنصر

            // حساب العدد الكلي
            var totalRecords = await query.CountAsync();

            // جلب البيانات المطلوبة
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResultDto<T>
            {
                Items = items,
                Pagination = new PaginationDto
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalRecords = totalRecords
                }
            };
        }

        public static PagedResultDto<T> CreatePagedResult<T>(
            List<T> items,
            int pageNumber,
            int pageSize,
            int totalRecords) where T : class
        {
            pageNumber = pageNumber < 1 ? 1 : pageNumber;
            pageSize = pageSize < 1 ? 10 : pageSize;

            return new PagedResultDto<T>
            {
                Items = items,
                Pagination = new PaginationDto
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalRecords = totalRecords
                }
            };
        }
    }
}