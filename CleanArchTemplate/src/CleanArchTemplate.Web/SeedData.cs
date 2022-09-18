// <copyright file="SeedData.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using CleanArchTemplate.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchTemplate.Web;

public static class SeedData
{

    public static void Initialize(IServiceProvider serviceProvider)
    {
        //using (var dbContext = new AppDbContext(
        //    serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
        //{
        //    // Look for any TODO items.
        //    //if (dbContext.ToDoItems.Any())
        //    //{
        //    //    return;   // DB has been seeded
        //    //}

        //    PopulateTestData(dbContext);


        //}
    }
    public static void PopulateTestData(AppDbContext dbContext)
    {
        
    }
}
