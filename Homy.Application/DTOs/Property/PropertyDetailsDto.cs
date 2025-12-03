using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homy.Application.DTOs.Property
{
    public class PropertyDetailsDto
    {
        public long Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal? RentPriceMonthly { get; set; }
        public int? Area { get; set; }
        public byte? Rooms { get; set; }
        public byte? Bathrooms { get; set; }
        public byte? FloorNumber { get; set; }

        public string CityName { get; set; } = null!;
        public string? DistrictName { get; set; }
        public string? ProjectName { get; set; }
        public string PropertyTypeName { get; set; } = null!;

        public string? FinishingType { get; set; } // "بدون تشطيب", "نصف تشطيب", "تشطيب كامل"
        public string Purpose { get; set; } = null!;

        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string? AddressDetails { get; set; }

        public bool IsAgricultural { get; set; }
        public bool IsFeatured { get; set; }

        public int ViewCount { get; set; }
        public int WhatsAppClicks { get; set; }
        public int PhoneClicks { get; set; }

        //Owner Info
        public Guid OwnerId { get; set; }
        public string OwnerName { get; set; } = null!;
        public string OwnerPhone { get; set; } = null!;
        public string? OwnerWhatsApp { get; set; }
        public string? OwnerProfileImage { get; set; }

        // Images
        public List<PropertyImageUploadDto> Images { get; set; } = new();

        // Amenities
        public List<string> Amenities { get; set; } = new();

        public DateTime CreatedAt { get; set; }
    }

    public class PropertyImageDto
    {
        public long Id { get; set; }
        public string ImageUrl { get; set; } = null!;
        public bool IsMain { get; set; }
        public int SortOrder { get; set; }
    }
}

