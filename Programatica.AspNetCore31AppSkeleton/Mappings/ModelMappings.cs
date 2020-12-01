using AutoMapper;
using Programatica.AspNetCore31AppSkeleton.Data.Models;
using Programatica.AspNetCore31AppSkeleton.ViewModels;

namespace Programatica.AspNetCore31AppSkeleton.Mappings
{
    public class ModelMappings : Profile
    {
        public ModelMappings()
        {
            CreateMap<Dummy, DummyViewModel>().ReverseMap();
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<Role, RoleViewModel>().ReverseMap();
            CreateMap<UserRole, UserRoleViewModel>()
                .ForMember(dest => dest.SelectedUserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.SelectedRoleId, opt => opt.MapFrom(src => src.RoleId));
            CreateMap<UserRoleViewModel, UserRole>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.SelectedUserId))
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.SelectedRoleId));
        }

    }
}
