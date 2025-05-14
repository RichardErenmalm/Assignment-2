using ApplicationLayer.Pipelinebehavior;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer
{
    public static class ApplicationDependencyInection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {


            var assembly = typeof(ApplicationDependencyInection).Assembly;
            services.AddMediatR(configutaion => configutaion.RegisterServicesFromAssembly(assembly));
            services.AddValidatorsFromAssembly(assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
