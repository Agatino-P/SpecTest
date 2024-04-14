using Microsoft.Extensions.DependencyInjection;
using SpecTest.Domain.Ports;
using SpecTest.Infrastructure.DbContextes;
using SpecTest.Infrastructure.Repositories;

namespace SpecTest.Infrastructure.ServiceExtensions;
public static class DbServiceExtensions
{
    public static IServiceCollection AddDbServices(this IServiceCollection services)
    {
        services.AddDbContext<SpecTestDbContext>();
        services.AddTransient<IPersonRepository, PersonRepository>();
        return services;
    }
}
