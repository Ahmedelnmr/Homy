using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homy.Application.DTOs.Property
{
    public class PropertySearchDto
    {
        public string? SearchTerm { get; set; }
        public long? CityId { get; set; }
        public long? DistrictId { get; set; }
        public long? PropertyTypeId { get; set; }
        public long? ProjectId { get; set; }

        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

        public int? MinArea { get; set; }
        public int? MaxArea { get; set; }

        public byte? MinRooms { get; set; }
        public byte? MaxRooms { get; set; }

        public byte? MinBathrooms { get; set; }

        public byte? Purpose { get; set; } // 1=Sale, 2=Rent, 3=Both
        public byte? FinishingType { get; set; }

        public bool? IsFeatured { get; set; }
        public bool? IsAgricultural { get; set; }

        // Pagination
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 12;

        // Sorting
        public string? SortBy { get; set; }
    }
}
