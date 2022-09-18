// <copyright file="DefaultInfrastructureDependencies.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using CleanArchTemplate.Core.Constants;
using CleanArchTemplate.Core.Interfaces;
using CleanArchTemplate.Infrastructure.Data;
using CleanArchTemplate.SharedKernel;
using CleanArchTemplate.SharedKernel.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArchTemplate.Infrastructure
{
    public static class DefaultInfrastructureDependencies
    {
        public static void AddDefaultInfrastructureDependencies(
            this IServiceCollection services,
            bool isDevelopment,
            Assembly callingAssembly = null)
        {
            var assemblies = GroupUpAllAssemblies(callingAssembly);

            if (isDevelopment)
            {
                RegisterDevelopmentOnlyDependencies(services);
            }
            else
            {
                RegisterProductionOnlyDependencies(services);
            }

            RegisterCommonDependencies(services, assemblies);
        }

        private static List<Assembly> GroupUpAllAssemblies(Assembly callingAssembly)
        {
            var assemblies = new List<Assembly>();

            var coreAssembly = Assembly.GetAssembly(typeof(AuthorizationConstants)); // TODO: Replace "Project" with any type from your Core project
            var infrastructureAssembly = Assembly.GetAssembly(typeof(StartupSetup));
            assemblies.Add(coreAssembly);
            assemblies.Add(infrastructureAssembly);
            if (callingAssembly != null)
            {
                assemblies.Add(callingAssembly);
            }

            return assemblies;
        }

        private static void RegisterCommonDependencies(IServiceCollection services, List<Assembly> assemblies)
        {
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));

            services.AddScoped<IEmailSender, EmailSender>();
        }

        private static void RegisterProductionOnlyDependencies(IServiceCollection services)
        {
        }

        private static void RegisterDevelopmentOnlyDependencies(IServiceCollection services)
        {
        }
    }
}
