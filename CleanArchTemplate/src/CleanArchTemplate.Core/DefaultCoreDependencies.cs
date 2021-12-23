// <copyright file="DefaultCoreDependencies.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using CleanArchTemplate.Core.Interfaces;
using CleanArchTemplate.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchTemplate.Core
{
    public static class DefaultCoreDependencies
    {
        public static void AddDefaultCoreDependencies(this IServiceCollection services)
        {
            services.AddScoped<IToDoItemSearchService, ToDoItemSearchService>();
        }
    }
}
