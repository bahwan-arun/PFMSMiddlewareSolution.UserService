using Microsoft.Extensions.DependencyInjection;
using PFMS.Middleware.Application.Services;
using PFMS.Middleware.Application.ServiceContracts;
using FluentValidation;
using PFMS.Middleware.Application.Validators;

namespace PFMS.Middleware.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddTransient<IUsersService, UsersService>();
            services.AddValidatorsFromAssemblyContaining<RegistrationValidatior>();
            return services;
        }
    }
}
