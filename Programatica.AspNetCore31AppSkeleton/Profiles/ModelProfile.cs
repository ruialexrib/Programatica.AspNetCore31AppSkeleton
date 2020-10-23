using AutoMapper;
using Programatica.AspNetCore31AppSkeleton.Data.Models;
using Programatica.AspNetCore31AppSkeleton.ViewModels;

namespace Programatica.AspNetCore31AppSkeleton.Profiles
{
    public class ModelProfile : Profile
    {
        public ModelProfile()
        {
            CreateMap<Dummy, DummyViewModel>().ReverseMap();
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<Role, RoleViewModel>().ReverseMap();
            CreateMap<UserRole, PermissionViewModel>()
                .ForMember(dest => dest.SelectedUserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.SelectedRoleId, opt => opt.MapFrom(src => src.RoleId))
                .ReverseMap();
        }

    }
}
