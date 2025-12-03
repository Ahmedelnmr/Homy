using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homy.Application.DTOs.Property
{
    public class PropertyListDto
    {
        public long Id { get; set; }
        public string Title { get; set; } = null!;
        public decimal Price { get; set; }
        public decimal? RentPriceMonthly { get; set; }
        public int? Area { get; set; }
        public byte? Rooms { get; set; }
        public byte? Bathrooms { get; set; }
        public string CityName { get; set; } = null!;
        public string? DistrictName { get; set; }
        public string PropertyTypeName { get; set; } = null!;
        public string? MainImageUrl { get; set; }
        public bool IsFeatured { get; set; }
        public string Purpose { get; set; } = null!; // "للبيع", "للإيجار", "كلاهما"
        public DateTime CreatedAt { get; set; }
    }
}
