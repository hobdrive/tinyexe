using System;

#if WINCE
namespace TinyExe
{
    public static class CompactFrameworkAdapter
    {
        public static string ToLowerInvariant(this string s)
        {
            return s.ToLower();
        }
        public static string ToUpperInvariant(this string s)
        {
            return s.ToUpper();
        }
    }
}
#endif
