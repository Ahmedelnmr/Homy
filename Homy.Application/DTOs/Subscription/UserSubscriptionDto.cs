using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homy.Application.DTOs.Subscription
{
    public class UserSubscriptionListDto
    {
        public long Id { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string PackageName { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public decimal AmountPaid { get; set; }
        public string? PaymentMethod { get; set; }
        public int DaysRemaining { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CreateUserSubscriptionDto
    {
        [Required(ErrorMessage = "المستخدم مطلوب")]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "الباقة مطلوبة")]
        public long PackageId { get; set; }

        public DateTime StartDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "تاريخ الانتهاء مطلوب")]
        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; } = true;

        [MaxLength(50)]
        public string? PaymentMethod { get; set; }

        [Required(ErrorMessage = "المبلغ المدفوع مطلوب")]
        [Range(0, double.MaxValue)]
        public decimal AmountPaid { get; set; }
    }

    public class UpdateUserSubscriptionDto
    {
        [Required]
        public long Id { get; set; }

        [Required(ErrorMessage = "تاريخ البداية مطلوب")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "تاريخ الانتهاء مطلوب")]
        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; }

        [MaxLength(50)]
        public string? PaymentMethod { get; set; }

        [Required(ErrorMessage = "المبلغ المدفوع مطلوب")]
        [Range(0, double.MaxValue)]
        public decimal AmountPaid { get; set; }
    }

    public class CancelSubscriptionDto
    {
        [Required]
        public long SubscriptionId { get; set; }

        [MaxLength(500)]
        public string? Reason { get; set; }
    }
}
