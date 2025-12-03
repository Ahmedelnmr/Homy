using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homy.Application.DTOs.Admin
{
    public class UserSearchDto
    {
        public string? SearchTerm { get; set; } // Name, Email, Phone
        public byte? Role { get; set; } // 1=Owner, 2=Agent, 3=Admin
        public bool? IsActive { get; set; }
        public bool? IsVerified { get; set; }
        public bool? HasActiveSubscription { get; set; }

        public DateTime? RegisteredFrom { get; set; }
        public DateTime? RegisteredTo { get; set; }

        // Pagination
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;

        // Sorting
        public string? SortBy { get; set; }
    }
}
