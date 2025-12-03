using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Homy.Application.Helpers
{
    public static class ValidationHelper
    {
        public static bool IsValidEgyptianPhone(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return false;

            // إزالة المسافات والرموز
            phoneNumber = Regex.Replace(phoneNumber, @"[\s\-\(\)]", "");

            // الأنماط المقبولة:
            // 01xxxxxxxxx (11 رقم)
            // +2001xxxxxxxxx
            // 002001xxxxxxxxx
            var pattern = @"^(01[0-2,5]{1}[0-9]{8}|(\+2|002)?01[0-2,5]{1}[0-9]{8})$";

            return Regex.IsMatch(phoneNumber, pattern);
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static (bool IsValid, string Message) ValidatePasswordStrength(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return (false, "كلمة المرور مطلوبة");

            if (password.Length < 6)
                return (false, "كلمة المرور يجب أن تكون 6 أحرف على الأقل");

            if (password.Length > 100)
                return (false, "كلمة المرور طويلة جداً");

            // (Optional) تحقق متقدم
            bool hasUpperCase = password.Any(char.IsUpper);
            bool hasLowerCase = password.Any(char.IsLower);
            bool hasDigit = password.Any(char.IsDigit);

            if (!hasDigit)
                return (false, "كلمة المرور يجب أن تحتوي على رقم واحد على الأقل");

            return (true, "كلمة المرور قوية");
        }

        public static string SanitizeHtml(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            // إزالة كل الـ HTML Tags
            return Regex.Replace(input, "<.*?>", string.Empty);
        }

        public static bool IsValidUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return false;

            return Uri.TryCreate(url, UriKind.Absolute, out Uri? uriResult)
                   && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
