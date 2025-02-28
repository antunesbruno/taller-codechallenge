using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Taller.CodeChallenge.Domain.Interfaces;
using Taller.CodeChallenge.Infrastructure.Adapters;
using Taller.CodeChallenge.Infrastructure.Repositories;
using Taller.CodeChallenge.Infrastructure.Repositories.DbContext;

namespace Taller.CodeChallenge.Infrastructure
{
    public static class Setup
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            #region Adapters

            services.AddScoped<IUsersAdapter, UsersAdapter>();

            #endregion


            #region Repositories

            services.AddScoped<IUsersRepository, UsersRepository>();

            #endregion

            #region DbContext

            AddDbContext(services);

            #endregion

            return services;
        }

        private static void AddDbContext(this IServiceCollection services)
        {
            services.AddDbContext<DbContextInMemory>(opt  => opt.UseInMemoryDatabase("codechallenge_db"));
        }
    }
}
