// <copyright file="List.ProjectListResponse.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace CleanArchTemplate.Web.Endpoints.ProjectEndpoints
{
    public class ProjectListResponse
    {
        public List<ProjectRecord> Projects { get; set; } = new();
    }
}
