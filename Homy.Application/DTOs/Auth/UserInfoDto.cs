using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homy.Application.DTOs.Auth
{
    public class UserInfoDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? WhatsAppNumber { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string Role { get; set; } = null!; // "Owner", "Agent", "Admin"
        public bool IsVerified { get; set; }
        public bool IsActive { get; set; }
    }
}
