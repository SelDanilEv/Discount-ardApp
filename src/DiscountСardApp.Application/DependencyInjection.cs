using System.Reflection;
using DiscountСardApp.Application.Common.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DiscountСardApp.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // register mapping profiles for AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // register Validators (FluentValidation)
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // register MediatR stuff
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            //TODO: register application services

            return services;
        }

    }
}