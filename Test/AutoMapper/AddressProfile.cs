using AutoMapper;
using Test.Models.Address;
using Test.ViewModels.Address;

namespace Test.AutoMapper;

public class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<AddressInputModel, Address>()
            .ForMember(a => a.Location, opt => opt.MapFrom(a => a.Location));
        CreateMap<Address, AddressViewModel>()
            .ForMember(a => a.Location, opt => opt.MapFrom(a => a.Location));
        CreateMap<AddressEditModel, Address>()
            .ForMember(a => a.Location, opt => opt.MapFrom(a => a.Location));



    }
}