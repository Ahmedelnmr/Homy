using Homy.Domin.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homy.Application.Helpers
{
    public static class EnumHelper
    {
        public static string GetFinishingTypeName(FinishingType? finishingType)
        {
            return finishingType switch
            {
                FinishingType.None => "بدون تشطيب",
                FinishingType.Semi => "نصف تشطيب",
                FinishingType.Full => "تشطيب كامل",
                _ => "غير محدد"
            };
        }
    

        public static string GetPropertyPurposeName(PropertyPurpose purpose)
        {
            return purpose switch
            {
                PropertyPurpose.ForSale => "للبيع",
                PropertyPurpose.ForRent => "للإيجار",
                PropertyPurpose.Both => "للبيع والإيجار",
                _ => "غير محدد"
            };
        }
        public static string GetPropertyStatusName(PropertyStatus status)
        {
            return status switch
            {
                PropertyStatus.Active => "نشط",
                PropertyStatus.SoldOrRented => "تم البيع/الإيجار",
                PropertyStatus.Hidden => "مخفي",
                _ => "غير معروف"
            };
        }
        public static string GetUserRoleName(UserRole role)
        {
            return role switch
            {
                UserRole.Owner => "Owner",
                UserRole.Agent => "Agent",
                UserRole.Admin => "Admin",
                _ => "Unknown"
            };
        }
        public static FinishingType? ParseFinishingType(string finishingType)
        {
            return finishingType?.ToLower() switch
            {
                "none" or "بدون تشطيب" => FinishingType.None,
                "semi" or "نصف تشطيب" => FinishingType.Semi,
                "full" or "تشطيب كامل" => FinishingType.Full,
                _ => null
            };
        }
        public static PropertyPurpose? ParsePropertyPurpose(string purpose)
        {
            return purpose?.ToLower() switch
            {
                "forsale" or "للبيع" => PropertyPurpose.ForSale,
                "forrent" or "للإيجار" => PropertyPurpose.ForRent,
                "both" or "للبيع والإيجار" => PropertyPurpose.Both,
                _ => null
            };
        }
        public static List<(byte Value, string Name)> GetAllFinishingTypes()
        {
            return new List<(byte, string)>
            {
                ((byte)FinishingType.None, "بدون تشطيب"),
                ((byte)FinishingType.Semi, "نصف تشطيب"),
                ((byte)FinishingType.Full, "تشطيب كامل")
            };
        }
        public static List<(byte Value, string Name)> GetAllPropertyPurposes()
        {
            return new List<(byte, string)>
            {
                ((byte)PropertyPurpose.ForSale, "للبيع"),
                ((byte)PropertyPurpose.ForRent, "للإيجار"),
                ((byte)PropertyPurpose.Both, "للبيع والإيجار")
            };
        }
    }
}
