using System;

// == Package Manager Console CheatSheet ============================================================
//
// == Get Help ==
// Get-Help about_EntityFrameworkCore
// == Create Migration ==
// Add-Migration InitialCreate -StartupProject Programatica.AspNetCore31AppSkeleton.Data.Migrations.Bootstrap
//                             -Project Programatica.AspNetCore31AppSkeleton.Data.Migrations
//                             -Verbose
// == Update Database ==
// Update-Database -StartupProject Programatica.AspNetCore31AppSkeleton.Data.Migrations.Bootstrap
//                 -Project Programatica.AspNetCore31AppSkeleton.Data.Migrations
//                 -Verbose


namespace Programatica.AspNetCore31AppSkeleton.Data.Migrations.Bootstrap
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
