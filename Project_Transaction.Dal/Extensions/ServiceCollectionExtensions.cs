using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Project_Transaction.Dal.Repositories;
using Project_Transaction.Domain.Abstractions.Repositories.Interface;


namespace Project_Transaction.Dal.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDal(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<DataContext>((serviceProvider, optionsBuilder) =>
            {
                
                optionsBuilder.UseNpgsql(configuration.GetConnectionString("PostgreSQL"));

                
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
        }
    }
}
