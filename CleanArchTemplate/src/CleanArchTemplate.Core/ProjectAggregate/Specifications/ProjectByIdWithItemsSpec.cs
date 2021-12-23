﻿// <copyright file="ProjectByIdWithItemsSpec.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using Ardalis.Specification;

namespace CleanArchTemplate.Core.ProjectAggregate.Specifications
{
    public class ProjectByIdWithItemsSpec : Specification<Project>, ISingleResultSpecification
    {
        public ProjectByIdWithItemsSpec(int projectId)
        {
            Query
                .Where(project => project.Id == projectId)
                .Include(project => project.Items);
        }
    }
}
