// <copyright file="ApiProjectsControllerList.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Ardalis.HttpClientTestExtensions;
using CleanArchTemplate.Web;
using CleanArchTemplate.Web.ApiModels;
using Xunit;

namespace CleanArchTemplate.FunctionalTests.ControllerApis
{
    [Collection("Sequential")]
    public class ProjectCreate : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public ProjectCreate(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnsOneProject()
        {
            var result = await _client.GetAndDeserialize<IEnumerable<ProjectDTO>>("/api/projects");

            Assert.Single(result);
            Assert.Contains(result, i => i.Name == SeedData.TestProject1.Name);
        }
    }
}
