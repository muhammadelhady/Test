using AutoMapper;
using Test.Models.User;
using Test.ViewModels.User;

namespace Test.AutoMapper;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserInputModel,User >()
            .ForMember(u=>u.Address,opt=>opt.MapFrom(u=>u.Address))
            .ForMember(u=>u.Company,opt=>opt.MapFrom(u=>u.Company));
        CreateMap<User,UserViewModel>()
            .ForMember(u=>u.Address,opt=>opt.MapFrom(u=>u.Address))
            .ForMember(u => u.Company, opt => opt.MapFrom(u => u.Company));
    }
}