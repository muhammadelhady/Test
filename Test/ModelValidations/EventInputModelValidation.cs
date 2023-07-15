using FluentValidation;
using Test.ViewModels.Event;
using Test.ViewModels.User;

namespace Test.ModelValidations
{
    public class EventInputModelValidation : AbstractValidator<EventInputModel>
    {
        public EventInputModelValidation() {
            RuleFor(e=> e.Title).NotEmpty().WithMessage("Title Cannot Be Empty");
            RuleFor(e=> e.OwnerUserId).NotEmpty().WithMessage("Owner Id Is Mandatory");
            RuleFor(e=> e.Description).NotEmpty().WithMessage("Description Cannot Be Empty");
            RuleFor(e=> e.StartDate).NotEmpty().WithMessage("Start Date Cannot Be Empty");
            RuleFor(e=> e.EndDate).NotEmpty().WithMessage("End Date Cannot Be Empty");
            RuleFor(e=> e.TimeZoneInfoId).NotEmpty().WithMessage("Time Zone Info Id Is Mandatory");

        }
    }
}
