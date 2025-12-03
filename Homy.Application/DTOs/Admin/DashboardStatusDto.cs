using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homy.Application.DTOs.Admin
{
    public class DashboardStatsDto
    {
        public int TotalUsers { get; set; }
        public int ActiveUsers { get; set; }
        public int BannedUsers { get; set; }

        public int TotalProperties { get; set; }
        public int ActiveProperties { get; set; }
        public int FeaturedProperties { get; set; }
        public int PendingReview { get; set; }

        public int TotalSubscriptions { get; set; }
        public int ActiveSubscriptions { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal MonthlyRevenue { get; set; }

        public List<RecentActivityDto> RecentActivities { get; set; } = new();
        public List<TopCityDto> TopCities { get; set; } = new();
    }

    public class RecentActivityDto
    {
        public string ActivityType { get; set; } = null!; // "new_user", "new_property", "new_subscription"
        public string Description { get; set; } = null!;
        public DateTime Timestamp { get; set; }
    }

    public class TopCityDto
    {
        public string CityName { get; set; } = null!;
        public int PropertiesCount { get; set; }
    }
}
