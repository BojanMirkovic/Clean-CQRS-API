
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<MockDatabase>();
            services.AddDbContext<RealDb>(options =>
            {
                options.UseSqlServer("Server=LAPTOP-D4IQ7VEN\\SQLEXPRESS; Database=API_Animals; Trusted_Connection=true; TrustServerCertificate=true;");

            });

            return services;
        }
    }
}
