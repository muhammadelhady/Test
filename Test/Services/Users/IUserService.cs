using Test.Helpers;
using Test.ViewModels.User;

namespace Test.Services.Users
{
    public interface IUserService
    {
        Task<UserViewModel> Create(UserInputModel userInputModel);
        Task<List<UserViewModel>> GetAll(BaseQueryParameters baseQueryParameters);
        Task<UserViewModel> GetById(int id);
        Task<List<UserViewModel>>GetByIds(List<int>userIds);
    }
}
