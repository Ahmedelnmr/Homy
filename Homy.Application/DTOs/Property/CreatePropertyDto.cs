using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homy.Application.DTOs.Property
{
    public class CreatePropertyDto
    {
        [Required(ErrorMessage = "عنوان الإعلان مطلوب")]
        [MaxLength(500, ErrorMessage = "العنوان لا يمكن أن يتجاوز 500 حرف")]
        public string Title { get; set; } = null!;

        [MaxLength(2000, ErrorMessage = "الوصف لا يمكن أن يتجاوز 2000 حرف")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "نوع العقار مطلوب")]
        public long PropertyTypeId { get; set; }

        [Required(ErrorMessage = "المدينة مطلوبة")]
        public long CityId { get; set; }

        public long? DistrictId { get; set; }
        public long? ProjectId { get; set; }

        [Required(ErrorMessage = "السعر مطلوب")]
        [Range(0, double.MaxValue, ErrorMessage = "السعر يجب أن يكون أكبر من 0")]
        public decimal Price { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "سعر الإيجار يجب أن يكون أكبر من 0")]
        public decimal? RentPriceMonthly { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "المساحة يجب أن تكون أكبر من 0")]
        public int? Area { get; set; }

        [Range(0, 50, ErrorMessage = "عدد الغرف يجب أن يكون بين 0 و 50")]
        public byte? Rooms { get; set; }

        [Range(0, 20, ErrorMessage = "عدد الحمامات يجب أن يكون بين 0 و 20")]
        public byte? Bathrooms { get; set; }

        [Range(0, 200, ErrorMessage = "رقم الطابق يجب أن يكون بين 0 و 200")]
        public byte? FloorNumber { get; set; }

        public byte? FinishingType { get; set; } // 0=None, 1=Semi, 2=Full

        [Required(ErrorMessage = "الغرض من العقار مطلوب")]
        public byte Purpose { get; set; } = 1; // 1=ForSale, 2=ForRent, 3=Both

        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }

        [MaxLength(1000)]
        public string? AddressDetails { get; set; }

        public bool IsAgricultural { get; set; } = false;

        // Amenities (IDs)
        public List<long> AmenityIds { get; set; } = new();
    }
}
