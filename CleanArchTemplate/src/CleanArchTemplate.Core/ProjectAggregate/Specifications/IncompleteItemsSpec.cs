// <copyright file="IncompleteItemsSpec.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using Ardalis.Specification;

namespace CleanArchTemplate.Core.ProjectAggregate.Specifications
{
    public class IncompleteItemsSpec : Specification<ToDoItem>
    {
        public IncompleteItemsSpec()
        {
            Query.Where(item => !item.IsDone);
        }
    }
}
