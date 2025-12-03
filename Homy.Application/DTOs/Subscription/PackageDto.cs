using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homy.Application.DTOs.Subscription
{
    public class PackageListDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int DurationDays { get; set; }
        public int MaxProperties { get; set; }
        public int MaxFeatured { get; set; }
        public bool CanBumpUp { get; set; }
        public int ActiveSubscriptionsCount { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class PackageDetailsDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int DurationDays { get; set; }
        public int MaxProperties { get; set; }
        public int MaxFeatured { get; set; }
        public bool CanBumpUp { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class CreatePackageDto
    {
        [Required(ErrorMessage = "اسم الباقة مطلوب")]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "السعر مطلوب")]
        [Range(0, double.MaxValue, ErrorMessage = "السعر يجب أن يكون أكبر من أو يساوي 0")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "مدة الباقة مطلوبة")]
        [Range(1, 365, ErrorMessage = "المدة يجب أن تكون بين 1 و 365 يوم")]
        public int DurationDays { get; set; } = 30;

        [Required(ErrorMessage = "الحد الأقصى للإعلانات مطلوب")]
        [Range(1, 1000, ErrorMessage = "الحد الأقصى يجب أن يكون بين 1 و 1000")]
        public int MaxProperties { get; set; } = 10;

        [Required(ErrorMessage = "الحد الأقصى للإعلانات المميزة مطلوب")]
        [Range(0, 100, ErrorMessage = "الحد الأقصى يجب أن يكون بين 0 و 100")]
        public int MaxFeatured { get; set; } = 3;

        public bool CanBumpUp { get; set; } = false;
    }

    public class UpdatePackageDto
    {
        [Required]
        public long Id { get; set; }

        [Required(ErrorMessage = "اسم الباقة مطلوب")]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "السعر مطلوب")]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "مدة الباقة مطلوبة")]
        [Range(1, 365)]
        public int DurationDays { get; set; }

        [Required(ErrorMessage = "الحد الأقصى للإعلانات مطلوب")]
        [Range(1, 1000)]
        public int MaxProperties { get; set; }

        [Required(ErrorMessage = "الحد الأقصى للإعلانات المميزة مطلوب")]
        [Range(0, 100)]
        public int MaxFeatured { get; set; }

        public bool CanBumpUp { get; set; }
    }
}
