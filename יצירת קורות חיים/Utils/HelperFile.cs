using Meziantou.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace יצירת_קורות_חיים.Utils
{
    public class HelperFile
    {
        public static string GetRootPath()
        {
            FullPath rootPath = FullPath.FromPath(@"Data\"); // It automatically calls Path.GetFullPath to resolve the path
            var v = rootPath.Parent.Parent.Parent.Parent;
            return v.Value;
        }
    }
}
