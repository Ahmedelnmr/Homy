using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Homy.Application.DTOs.Property
{
    public class PropertyImageUploadDto
    {

        [Required]
        public long PropertyId { get; set; }

        [Required(ErrorMessage = "يجب اختيار صورة")]
        public IFormFile ImageFile { get; set; } = null!;

        public bool IsMain { get; set; } = false;
        public int SortOrder { get; set; } = 0;
    }

    public class MultipleImagesUploadDto
    {
        [Required]
        public long PropertyId { get; set; }

        [Required(ErrorMessage = "يجب اختيار صور")]
        [MinLength(1, ErrorMessage = "يجب اختيار صورة واحدة على الأقل")]
        public List<IFormFile> ImageFiles { get; set; } = new();

        public int? MainImageIndex { get; set; } // Index of the main image (0-based)
    }
}

