using FluentValidation;
using Test.ViewModels.Event;
using Test.ViewModels.Invitaion;
using Test.ViewModels.User;

namespace Test.Configurations;

public static class ValidationSetup
{
    public static IServiceCollection SetupFluentValidation(this IServiceCollection services)
    {

        services.AddValidatorsFromAssemblyContaining<UserInputModel>();
        services.AddValidatorsFromAssemblyContaining<EventEditModel>();
        services.AddValidatorsFromAssemblyContaining<EventInputModel>();
        services.AddValidatorsFromAssemblyContaining<InvitaionResponseInputModel>();
        services.AddValidatorsFromAssemblyContaining<SendInvitationInputModel>();
        return services;
    }
}