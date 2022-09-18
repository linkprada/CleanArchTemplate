// <copyright file="StartupSetup.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using CleanArchTemplate.Infrastructure.Data;
using CleanArchTemplate.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchTemplate.Infrastructure;

public static class StartupSetup
{
    public static void AddDbContext(this IServiceCollection services, string connectionString) =>
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(connectionString)); // will be created in web project root

    public static void AddIdentityDbContext(this IServiceCollection services, string connectionString) =>
            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlite(connectionString)); // will be created in web project root
}
