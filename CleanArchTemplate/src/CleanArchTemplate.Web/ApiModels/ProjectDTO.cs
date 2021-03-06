// <copyright file="ProjectDTO.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace CleanArchTemplate.Web.ApiModels
{
    // ApiModel DTOs are used by ApiController classes and are typically kept in a side-by-side folder
    public class ProjectDTO : CreateProjectDTO
    {
        public int Id { get; set; }
        public List<ToDoItemDTO> Items = new();
    }

    // Creation DTOs should not include an ID if the ID will be generated by the back end
    public class CreateProjectDTO
    {
        public string Name { get; set; }
    }
}
