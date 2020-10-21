using AutoMapper;
using Programatica.AspNetCore31AppSkeleton.Data.Models;
using Programatica.AspNetCore31AppSkeleton.ViewModels;

namespace Programatica.AspNetCore31AppSkeleton.Profiles
{
    public class DummyProfile : Profile
    {
        public DummyProfile()
        {
            CreateMap<Dummy, DummyViewModel>().ReverseMap();
        }

    }
}
