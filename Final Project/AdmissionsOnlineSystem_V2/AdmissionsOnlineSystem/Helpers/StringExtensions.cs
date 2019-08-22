using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdmissionsOnlineSystem.Helpers
{
    public static class StringExtensions
    {
        public static T ParseEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}