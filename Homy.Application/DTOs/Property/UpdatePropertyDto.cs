using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homy.Application.DTOs.Property
{
    public class UpdatePropertyDto
    {
        [Required]
        public long Id { get; set; }

        [Required(ErrorMessage = "عنوان الإعلان مطلوب")]
        [MaxLength(500)]
        public string Title { get; set; } = null!;

        [MaxLength(2000)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "نوع العقار مطلوب")]
        public long PropertyTypeId { get; set; }

        [Required(ErrorMessage = "المدينة مطلوبة")]
        public long CityId { get; set; }

        public long? DistrictId { get; set; }
        public long? ProjectId { get; set; }

        [Required(ErrorMessage = "السعر مطلوب")]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        public decimal? RentPriceMonthly { get; set; }
        public int? Area { get; set; }
        public byte? Rooms { get; set; }
        public byte? Bathrooms { get; set; }
        public byte? FloorNumber { get; set; }
        public byte? FinishingType { get; set; }
        public byte Purpose { get; set; }

        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string? AddressDetails { get; set; }
        public bool IsAgricultural { get; set; }

        public List<long> AmenityIds { get; set; } = new();
    }
}
