// <copyright file="BaseEfRepoTestFixture.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using CleanArchTemplate.Infrastructure.Data;
using CleanArchTemplate.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace CleanArchTemplate.IntegrationTests.Data;

public abstract class BaseEfRepoTestFixture
{
    protected AppDbContext _dbContext;

    protected BaseEfRepoTestFixture()
    {
        var options = CreateNewContextOptions();

        _dbContext = new AppDbContext(options);
    }

    protected static DbContextOptions<AppDbContext> CreateNewContextOptions()
    {
        // Create a fresh service provider, and therefore a fresh
        // InMemory database instance.
        var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkInMemoryDatabase()
            .BuildServiceProvider();

        // Create a new options instance telling the context to use an
        // InMemory database and the new service provider.
        var builder = new DbContextOptionsBuilder<AppDbContext>();
        builder.UseInMemoryDatabase("cleanarchitecture")
               .UseInternalServiceProvider(serviceProvider);

        return builder.Options;
    }

    //protected EfRepository<Project> GetRepository()
    //{
    //    return new EfRepository<Project>(_dbContext);
    //}
}
