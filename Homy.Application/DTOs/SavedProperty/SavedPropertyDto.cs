using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homy.Application.DTOs.SavedProperty
{
    public class SavedPropertyListDto
    {
        public long Id { get; set; }
        public long PropertyId { get; set; }
        public string PropertyTitle { get; set; } = null!;
        public decimal Price { get; set; }
        public string CityName { get; set; } = null!;
        public string? DistrictName { get; set; }
        public string PropertyTypeName { get; set; } = null!;
        public string? MainImageUrl { get; set; }
        public DateTime SavedAt { get; set; }
    }

    public class AddSavedPropertyDto
    {
        [Required(ErrorMessage = "العقار مطلوب")]
        public long PropertyId { get; set; }
    }

    public class RemoveSavedPropertyDto
    {
        [Required(ErrorMessage = "العقار مطلوب")]
        public long PropertyId { get; set; }
    }
}
