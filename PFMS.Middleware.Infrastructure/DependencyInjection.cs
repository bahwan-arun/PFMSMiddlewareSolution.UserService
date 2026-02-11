using Microsoft.Extensions.DependencyInjection;
using PFMS.Middleware.Application.RepositoryContracts;
using PFMS.Middleware.Infrastructure.DBContext;
using PFMS.Middleware.Infrastructure.Repositories;

namespace PFMS.Middleware.Infrastructure
{
    public  static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IUsersRepository, UserRespository>();
            services.AddScoped<DapperDbContext>();
            return services;

        }

    }
}
