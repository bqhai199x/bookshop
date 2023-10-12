using System.Diagnostics.CodeAnalysis;

namespace Utilities
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Check Null or White Space.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsBlank([MaybeNullWhen(true)] this string? str)
        {
            return string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str);
        }

        /// <summary>
        /// Check not Null and White Space.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNotBlank([NotNullWhen(true)] this string? str)
        {
            return !string.IsNullOrEmpty(str) && !string.IsNullOrWhiteSpace(str);
        }
    }
}