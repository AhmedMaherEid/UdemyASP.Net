using System.Text.RegularExpressions;

namespace LoginUsingMiddleware.Helpers
{
    public static partial class EmailHelper
    {
        public const string AdminEmail = "admin@example.com";
        public const string AdminPassword = "admin1234";

        [GeneratedRegex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.com$")]
        private static partial Regex emailRegex();

        public static bool IsEmailFormat(string? emailFormat)
        {
            if (emailFormat != null)
                return emailRegex().IsMatch(emailFormat);
            else 
                return false;
        }
    }
}
