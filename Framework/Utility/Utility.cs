using System;

namespace Framework.Utility
{
    public static class Utility
    {
        public static bool IsValidFileName(this string fileName)
        {
            var fn = fileName.ToLower();
            if (fn.Contains(".php") || fn.Contains(".asp") || fn.Contains(".rb") || fn.Contains(".exe"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static string ToUniqueFileName(this string fileName)
        {
            var str = Guid.NewGuid().ToString().Replace("-", "_");
            return $"{str}_{fileName}";
        }
    }
}
