using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TEST.Application.SeedWork.Interfaces;
using TEST.Infrastructure.Database;

namespace TEST.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));


            services.AddScoped<IApplicationDbContext>(scope => scope.GetRequiredService<ApplicationDbContext>());


            return services;
        }
    }
}
