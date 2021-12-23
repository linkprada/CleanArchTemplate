﻿// <copyright file="Update.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using CleanArchTemplate.Core.ProjectAggregate;
using CleanArchTemplate.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CleanArchTemplate.Web.Endpoints.ProjectEndpoints
{
    public class Update : BaseAsyncEndpoint
        .WithRequest<UpdateProjectRequest>
        .WithResponse<UpdateProjectResponse>
    {
        private readonly IRepository<Project> _repository;

        public Update(IRepository<Project> repository)
        {
            _repository = repository;
        }

        [HttpPut(UpdateProjectRequest.Route)]
        [SwaggerOperation(
            Summary = "Updates a Project",
            Description = "Updates a Project with a longer description",
            OperationId = "Projects.Update",
            Tags = new[] { "ProjectEndpoints" })
        ]
        public override async Task<ActionResult<UpdateProjectResponse>> HandleAsync(UpdateProjectRequest request,
            CancellationToken cancellationToken)
        {
            var existingProject = await _repository.GetByIdAsync(request.Id); // TODO: pass cancellation token

            existingProject.UpdateName(request.Name);

            await _repository.UpdateAsync(existingProject); // TODO: pass cancellation token

            var response = new UpdateProjectResponse()
            {
                Project = new ProjectRecord(existingProject.Id, existingProject.Name),
            };
            return Ok(response);
        }
    }
}
