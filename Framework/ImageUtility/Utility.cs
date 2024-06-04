using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.ImageUtility
{
    public static class Utility
    {
        public static bool IsValidFileName(this string fileName)
        {
             var fName=fileName.ToLower();
             if (fName.Contains(".php") || fName.Contains(".asp") || fName.Contains(".rb") || fName.Contains(".exe"))
             {
                 return false;
             }
             return true;
        }
        public static string ToUniqueFileName(this string fileName)
        {
            var fName=Guid.NewGuid().ToString().Replace("-","_");
            return $"{fName}_{fileName}";
        }
    }
}
