using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homy.Application.DTOs.Admin
{
    public class UserListDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? WhatsAppNumber { get; set; }
        public string Role { get; set; } = null!;
        public bool IsVerified { get; set; }
        public bool IsActive { get; set; }
        public int TotalProperties { get; set; }
        public bool HasActiveSubscription { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class UserDetailsDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? WhatsAppNumber { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string Role { get; set; } = null!;
        public bool IsVerified { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        // Statistics
        public int TotalProperties { get; set; }
        public int ActiveProperties { get; set; }
        public int FeaturedProperties { get; set; }

        // Subscription Info
        public UserSubscriptionInfoDto? CurrentSubscription { get; set; }
    }

    public class UserSubscriptionInfoDto
    {
        public long SubscriptionId { get; set; }
        public string PackageName { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public int DaysRemaining { get; set; }
    }
}
