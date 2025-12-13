using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace OnionVb02.ValidatorStructor.DependencyResolvers
{
    public static class ValidatorResolver
    {
        public static void AddValidatorService(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
