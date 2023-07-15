using FluentValidation;
using Test.ViewModels.User;

namespace Test.ModelValidations
{
    public class UserInputModelValidation : AbstractValidator<UserInputModel>
    {
        public UserInputModelValidation()
        {
            RuleFor(user => user.Name).NotEmpty().WithMessage("Name Cannot Be Empty");
            RuleFor(user => user.UserName).NotEmpty().WithMessage("UserName Cannot Be Empty");
            RuleFor(user => user.phone).NotEmpty().WithMessage("phone Cannot Be Empty");
            RuleFor(user => user.Email).NotEmpty().WithMessage("Email Cannot Be Empty");
        }
    }
}
