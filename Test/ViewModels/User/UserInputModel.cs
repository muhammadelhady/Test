using Test.Models.User;
using Test.ViewModels.Address;

namespace Test.ViewModels.User
{
    public class UserInputModel
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string phone { get; set; }
        public AddressInputModel Address { get; set; }
        public Company Company { get; set; }

    }
}
