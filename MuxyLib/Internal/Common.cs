using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuxyLib.Internal
{
    internal static class Common
    {
        public static DateTime DateTimeStringToObject(string dateTime)
        {
            if (dateTime == null)
                return new DateTime();
            return Convert.ToDateTime(dateTime);
        }
    }
}
