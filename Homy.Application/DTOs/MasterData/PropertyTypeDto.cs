using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homy.Application.DTOs.MasterData
{
    public class PropertyTypeListDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? IconUrl { get; set; }
        public int PropertiesCount { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class PropertyTypeSimpleDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? IconUrl { get; set; }
    }

    public class CreatePropertyTypeDto
    {
        [Required(ErrorMessage = "اسم النوع مطلوب")]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [MaxLength(500)]
        [Url(ErrorMessage = "رابط الأيقونة غير صحيح")]
        public string? IconUrl { get; set; }
    }

    public class UpdatePropertyTypeDto
    {
        [Required]
        public long Id { get; set; }

        [Required(ErrorMessage = "اسم النوع مطلوب")]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [MaxLength(500)]
        [Url(ErrorMessage = "رابط الأيقونة غير صحيح")]
        public string? IconUrl { get; set; }
    }
}
