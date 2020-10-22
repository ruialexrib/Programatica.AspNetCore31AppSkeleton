using Programatica.Framework.Data.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Programatica.AspNetCore31AppSkeleton.ViewModels
{
    public class DummyViewModel : BaseModel
    {
        [Required]
        public string Description { get; set; }

    }
}
