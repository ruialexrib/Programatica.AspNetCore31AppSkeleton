using Programatica.AspNetCore31AppSkeleton.ViewModels.Base;
using System.ComponentModel.DataAnnotations;

namespace Programatica.AspNetCore31AppSkeleton.ViewModels
{
    public class DummyViewModel : BaseViewModel
    {
        [Required]
        public string Description { get; set; }

    }
}
