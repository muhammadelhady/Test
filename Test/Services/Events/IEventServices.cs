using Test.Helpers;
using Test.ViewModels.Event;

namespace Test.Services.Events
{
    public interface IEventServices
    {
        Task<EventViewModel>Create (EventInputModel eventInputModel);
        Task<List<EventViewModel>> GetEvents(BaseQueryParameters baseQueryParameters);
        Task<EventViewModel> GetById(int id);
        Task<EventViewModel> Edit(EventEditModel eventEditInputModel,int eventId);
        Task<bool> Delete(int id);
    }
}
