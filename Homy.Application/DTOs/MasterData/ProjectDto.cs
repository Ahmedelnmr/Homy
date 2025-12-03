using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homy.Application.DTOs.MasterData
{
    public class ProjectListDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? LogoUrl { get; set; }
        public string CityName { get; set; } = null!;
        public string? DistrictName { get; set; }
        public bool IsActive { get; set; }
        public int PropertiesCount { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class ProjectDetailsDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? LogoUrl { get; set; }
        public string? CoverImageUrl { get; set; }
        public long CityId { get; set; }
        public string CityName { get; set; } = null!;
        public long? DistrictId { get; set; }
        public string? DistrictName { get; set; }
        public string? LocationDescription { get; set; }
        public bool IsActive { get; set; }
        public int PropertiesCount { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class ProjectSimpleDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? LogoUrl { get; set; }
    }

    public class CreateProjectDto
    {
        [Required(ErrorMessage = "اسم المشروع مطلوب")]
        [MaxLength(300)]
        public string Name { get; set; } = null!;

        [MaxLength(500)]
        [Url(ErrorMessage = "رابط اللوجو غير صحيح")]
        public string? LogoUrl { get; set; }

        [MaxLength(1000)]
        [Url(ErrorMessage = "رابط الصورة الرئيسية غير صحيح")]
        public string? CoverImageUrl { get; set; }

        [Required(ErrorMessage = "المدينة مطلوبة")]
        public long CityId { get; set; }

        public long? DistrictId { get; set; }

        [MaxLength(1000)]
        public string? LocationDescription { get; set; }

        public bool IsActive { get; set; } = true;
    }

    public class UpdateProjectDto
    {
        [Required]
        public long Id { get; set; }

        [Required(ErrorMessage = "اسم المشروع مطلوب")]
        [MaxLength(300)]
        public string Name { get; set; } = null!;

        [MaxLength(500)]
        [Url(ErrorMessage = "رابط اللوجو غير صحيح")]
        public string? LogoUrl { get; set; }

        [MaxLength(1000)]
        [Url(ErrorMessage = "رابط الصورة الرئيسية غير صحيح")]
        public string? CoverImageUrl { get; set; }

        [Required(ErrorMessage = "المدينة مطلوبة")]
        public long CityId { get; set; }

        public long? DistrictId { get; set; }

        [MaxLength(1000)]
        public string? LocationDescription { get; set; }

        public bool IsActive { get; set; }
    }
}
