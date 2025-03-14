using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Project_Transaction.Application.EntityServices;
using Project_Transaction.Application.EntityServices.Abstraction;

namespace Project_Transaction.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<ITransactionService, TransactionService>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
