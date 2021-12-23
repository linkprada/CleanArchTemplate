﻿// <copyright file="Project_AddItem.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System;
using CleanArchTemplate.Core.ProjectAggregate;
using Xunit;

namespace CleanArchTemplate.UnitTests.Core.ProjectAggregate
{
    public class Project_AddItem
    {
        private Project _testProject = new Project("some name");

        [Fact]
        public void AddsItemToItems()
        {
            var _testItem = new ToDoItem
            {
                Title = "title",
                Description = "description",
            };

            _testProject.AddItem(_testItem);

            Assert.Contains(_testItem, _testProject.Items);
        }

        [Fact]
        public void ThrowsExceptionGivenNullItem()
        {
            Action action = () => _testProject.AddItem(null);

            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("newItem", ex.ParamName);
        }
    }
}
