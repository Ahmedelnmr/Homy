using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homy.Application.DTOs.Admin
{
    public class PropertyReviewListDto
    {
        public long Id { get; set; }
        public string Title { get; set; } = null!;
        public string PropertyTypeName { get; set; } = null!;
        public string CityName { get; set; } = null!;
        public string? DistrictName { get; set; }
        public decimal Price { get; set; }
        public string OwnerName { get; set; } = null!;
        public string OwnerPhone { get; set; } = null!;
        public string Status { get; set; } = null!; // "Active", "SoldOrRented", "Hidden"
        public DateTime CreatedAt { get; set; }
        public string? MainImageUrl { get; set; }
    }

    public class ApprovePropertyDto
    {
        [Required]
        public long PropertyId { get; set; }
    }

    public class RejectPropertyDto
    {
        [Required]
        public long PropertyId { get; set; }

        [Required(ErrorMessage = "سبب الرفض مطلوب")]
        [MaxLength(500)]
        public string Reason { get; set; } = null!;
    }

    public class ChangePropertyStatusDto
    {
        [Required]
        public long PropertyId { get; set; }

        [Required(ErrorMessage = "الحالة مطلوبة")]
        public byte Status { get; set; } // 1=Active, 2=SoldOrRented, 3=Hidden

        [MaxLength(500)]
        public string? Reason { get; set; }
    }
}
