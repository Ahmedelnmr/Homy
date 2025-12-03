using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homy.Application.DTOs.MasterData
{
    public class AmenityListDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? IconUrl { get; set; }
        public int UsageCount { get; set; } // عدد العقارات اللي فيها الـ Amenity دي
        public DateTime CreatedAt { get; set; }
    }

    public class AmenitySimpleDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? IconUrl { get; set; }
    }

    public class CreateAmenityDto
    {
        [Required(ErrorMessage = "اسم الميزة مطلوب")]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [MaxLength(500)]
        [Url(ErrorMessage = "رابط الأيقونة غير صحيح")]
        public string? IconUrl { get; set; }
    }

    public class UpdateAmenityDto
    {
        [Required]
        public long Id { get; set; }

        [Required(ErrorMessage = "اسم الميزة مطلوب")]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [MaxLength(500)]
        [Url(ErrorMessage = "رابط الأيقونة غير صحيح")]
        public string? IconUrl { get; set; }
    }
}
