using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programatica.AspNetCore31AppSkeleton.Extensions
{
    public static class ListExtensions
    {
        public static List<T> OrEmptyIfNull<T>(this List<T> source)
        {
            return source ?? new List<T>();
        }
    }
}
