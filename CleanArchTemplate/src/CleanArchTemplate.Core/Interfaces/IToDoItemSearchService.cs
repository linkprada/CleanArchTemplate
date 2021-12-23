// <copyright file="IToDoItemSearchService.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.Result;
using CleanArchTemplate.Core.ProjectAggregate;

namespace CleanArchTemplate.Core.Interfaces
{
    public interface IToDoItemSearchService
    {
        Task<Result<ToDoItem>> GetNextIncompleteItemAsync(int projectId);
        Task<Result<List<ToDoItem>>> GetAllIncompleteItemsAsync(int projectId, string searchString);
    }
}
