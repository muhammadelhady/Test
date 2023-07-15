using Test.Models.User;
using Test.ViewModels.Address;

namespace Test.ViewModels.User
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; } 
        public string? CreatedBy { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string phone { get; set; }
        public AddressViewModel Address { get; set; }
        public Company Company { get; set; }

    }
}
