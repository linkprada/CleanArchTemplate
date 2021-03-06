// <copyright file="ToDoItemViewModel.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using CleanArchTemplate.Core.ProjectAggregate;

namespace CleanArchTemplate.Web.ViewModels
{
    public class ToDoItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; private set; }

        public static ToDoItemViewModel FromToDoItem(ToDoItem item)
        {
            return new ToDoItemViewModel()
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                IsDone = item.IsDone,
            };
        }
    }
}
