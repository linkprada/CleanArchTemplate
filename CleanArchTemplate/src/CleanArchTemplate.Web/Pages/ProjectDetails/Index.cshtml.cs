// <copyright file="Index.cshtml.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System.Linq;
using System.Threading.Tasks;
using CleanArchTemplate.Core.ProjectAggregate;
using CleanArchTemplate.Core.ProjectAggregate.Specifications;
using CleanArchTemplate.SharedKernel.Interfaces;
using CleanArchTemplate.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CleanArchTemplate.Web.Pages.ToDoRazorPage
{
    public class IndexModel : PageModel
    {
        private readonly IRepository<Project> _repository;

        [BindProperty(SupportsGet = true)]
        public int ProjectId { get; set; }
        public string Message { get; set; } = "";

        public ProjectDTO Project { get; set; }

        public IndexModel(IRepository<Project> repository)
        {
            _repository = repository;
        }

        public async Task OnGetAsync()
        {
            var projectSpec = new ProjectByIdWithItemsSpec(ProjectId);
            var project = await _repository.GetBySpecAsync(projectSpec);

            if (project == null)
            {
                Message = "No project found.";
                return;
            }

            Project = new ProjectDTO
            {
                Id = project.Id,
                Name = project.Name,
                Items = project.Items
                .Select(item => ToDoItemDTO.FromToDoItem(item))
                .ToList(),
            };
        }
    }
}
