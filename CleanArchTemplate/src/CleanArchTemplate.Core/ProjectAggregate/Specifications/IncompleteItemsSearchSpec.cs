// <copyright file="IncompleteItemsSearchSpec.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using Ardalis.Specification;

namespace CleanArchTemplate.Core.ProjectAggregate.Specifications
{
    public class IncompleteItemsSearchSpec : Specification<ToDoItem>
    {
        public IncompleteItemsSearchSpec(string searchString)
        {
            Query
                .Where(item => !item.IsDone &&
                (item.Title.Contains(searchString) ||
                item.Description.Contains(searchString)));
        }
    }
}
