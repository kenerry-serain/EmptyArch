using AutoMapper;
using EmptyArch.Application.Abstractions;
using EmptyArch.Application.Services;
using EmptyArch.Domain.Abstractions;
using EmptyArch.Domain.Services;
using EmptyArch.Infrastructure.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EmptyArch.Infrastructure.IoC.Bootstrapper
{
    public static class IoCManager
    {
        public static void RegisterDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IPersonApplicationService, PersonApplicationService>();
            serviceCollection.AddScoped<IPersonDomainService, PersonDomainService>();
            serviceCollection.AddScoped<IPersonRepository, PersonRepository>();

            var assemblies = new[]
            {
                Assembly.GetAssembly(typeof(IPersonApplicationService)),
                Assembly.GetAssembly(typeof(IPersonDomainService)),
                Assembly.GetAssembly(typeof(IPersonRepository)),
            };

            serviceCollection.AddAutoMapper(assemblies);
        }
    }
}
