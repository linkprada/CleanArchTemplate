﻿// <copyright file="EfRepositoryDelete.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using CleanArchTemplate.Core.ProjectAggregate;
using Xunit;

namespace CleanArchTemplate.IntegrationTests.Data
{
    public class EfRepositoryDelete : BaseEfRepoTestFixture
    {
        [Fact]
        public async Task DeletesItemAfterAddingIt()
        {
            // add a project
            var repository = GetRepository();
            var initialName = Guid.NewGuid().ToString();
            var project = new Project(initialName);
            await repository.AddAsync(project);

            // delete the item
            await repository.DeleteAsync(project);

            // verify it's no longer there
            Assert.DoesNotContain(await repository.ListAsync(),
                project => project.Name == initialName);
        }
    }
}
