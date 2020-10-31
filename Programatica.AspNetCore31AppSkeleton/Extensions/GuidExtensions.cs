//using System;

//namespace Programatica.AspNetCore31AppSkeleton.Extensions
//{
//    public static class GuidExtensions
//    {
//        public static string JsNormalize(this Guid guid)
//        {
//            var b = guid.ToByteArray();
//            b[3] |= 0xF0;
//            return new Guid(b).ToString().Replace("-", "");
//        }
//    }
//}
