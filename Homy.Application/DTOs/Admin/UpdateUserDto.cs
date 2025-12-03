using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homy.Application.DTOs.Admin
{
    public class UpdateUserDto
    {
        [Required]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "الاسم مطلوب")]
        [MaxLength(200)]
        public string FullName { get; set; } = null!;

        [Required(ErrorMessage = "البريد الإلكتروني مطلوب")]
        [EmailAddress(ErrorMessage = "البريد الإلكتروني غير صحيح")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "رقم الهاتف مطلوب")]
        [Phone]
        [MaxLength(20)]
        public string PhoneNumber { get; set; } = null!;

        [Phone]
        [MaxLength(20)]
        public string? WhatsAppNumber { get; set; }

        [Required(ErrorMessage = "الدور مطلوب")]
        public byte Role { get; set; } // 1=Owner, 2=Agent, 3=Admin

        public bool IsVerified { get; set; }
        public bool IsActive { get; set; }
    }

    public class BanUserDto
    {
        [Required]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "سبب الحظر مطلوب")]
        [MaxLength(500)]
        public string Reason { get; set; } = null!;
    }

    public class UnbanUserDto
    {
        [Required]
        public Guid UserId { get; set; }
    }
}
