using Exam.DAL.Repositories.Contracts;
using Exam.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Exam.DAL
{
    public static class DataAccessLayerServiceRegistration
    {
        public static IServiceCollection AddDalServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(EfCoreRepository<>));

            return services;
        }
    }
}
