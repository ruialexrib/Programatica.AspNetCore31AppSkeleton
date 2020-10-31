using shortid;
using shortid.Configuration;
using System;

namespace Programatica.AspNetCore31AppSkeleton.Infrastructure
{
    public struct Razor
    {
        public static string Rnd()
        {
            //var b =Guid.NewGuid().ToByteArray();
            //b[3] |= 0xF0;
            //return new Guid(b).ToString().Replace("-", "");
            return ShortId.Generate(new GenerationOptions
            {
                UseNumbers = false,
                UseSpecialCharacters = false,
                Length = 8
            });

        }
    }
}
