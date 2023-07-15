using Test.Mapper;
using Test.Services.Events;
using Test.Services.Invetation;
using Test.Services.Users;

namespace Test.Configurations;

public static class DependencyInjectionConfig
{
    public static IServiceCollection SetupInfrastructureDependencyInjection(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.SetupFluentValidation();


        return services;
    }

    public static IServiceCollection SetupBusinessDependencyInjection(this IServiceCollection services)
    {

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IEventServices, EventService>();
        services.AddScoped<IInvitaionService, InvitaionService>();
        services.AddScoped<InivationMapper>();



        return services;
    }
}