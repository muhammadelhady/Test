using AutoMapper;
using Test.Models.Event;
using Test.Models.User;
using Test.ViewModels.Event;
using Test.ViewModels.User;

namespace Test.AutoMapper;

public class EventProfile : Profile
{
    public EventProfile()
    {
        CreateMap<EventInputModel, Event>()
            .ForMember(e => e.Address, opt => opt.MapFrom(e => e.Address));
        CreateMap<Event, EventViewModel>()
            .ForMember(e => e.Address, opt => opt.MapFrom(e => e.Address));
        CreateMap<EventEditModel, Event>()
            .ForMember(e => e.Address, opt => opt.MapFrom(e => e.Address));
    }
}