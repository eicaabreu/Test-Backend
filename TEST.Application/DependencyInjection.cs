using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TEST.Application.SeedWork.Behaviours;
using System.Reflection;


namespace TEST.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(executingAssembly);
            services.AddValidatorsFromAssembly(executingAssembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            return services;
        }
    }
}
