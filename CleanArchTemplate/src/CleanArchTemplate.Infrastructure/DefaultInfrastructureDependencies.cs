﻿// <copyright file="DefaultInfrastructureDependencies.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Reflection;
using CleanArchTemplate.Core.Interfaces;
using CleanArchTemplate.Core.ProjectAggregate;
using CleanArchTemplate.Infrastructure.Data;
using CleanArchTemplate.SharedKernel.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

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

            var coreAssembly = Assembly.GetAssembly(typeof(Project)); // TODO: Replace "Project" with any type from your Core project
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

            services.AddMediatR(assemblies.ToArray());
        }

        private static void RegisterProductionOnlyDependencies(IServiceCollection services)
        {
        }

        private static void RegisterDevelopmentOnlyDependencies(IServiceCollection services)
        {
        }
    }
}
