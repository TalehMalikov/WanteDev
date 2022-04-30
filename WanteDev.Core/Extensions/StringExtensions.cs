namespace WantedDev.Core.Extensions
{
    public static class StringExtensions
    {
        public static bool ISNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }
    }
}
