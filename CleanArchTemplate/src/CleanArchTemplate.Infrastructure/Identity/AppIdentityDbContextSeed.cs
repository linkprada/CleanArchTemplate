// <copyright file="AppIdentityDbContextSeed.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using CleanArchTemplate.Core.Constants;
using Microsoft.AspNetCore.Identity;

namespace CleanArchTemplate.Infrastructure.Identity
{
    public static class AppIdentityDbContextSeed
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(AuthorizationConstants.Roles.ADMINISTRATORS));

            string defaultUserName = "demouser@test.test";
            var defaultUser = new ApplicationUser
            {
                UserName = defaultUserName,
                Email = defaultUserName,
                EmailConfirmed = true,
            };
            await userManager.CreateAsync(defaultUser, AuthorizationConstants.DEFAULT_PASSWORD);

            string adminUserName = "admin@test.test";
            var adminUser = new ApplicationUser
            {
                UserName = adminUserName,
                Email = adminUserName,
                EmailConfirmed = true,
            };
            await userManager.CreateAsync(adminUser, AuthorizationConstants.DEFAULT_PASSWORD);
            adminUser = await userManager.FindByNameAsync(adminUserName);
            await userManager.AddToRoleAsync(adminUser, AuthorizationConstants.Roles.ADMINISTRATORS);
        }
    }
}
