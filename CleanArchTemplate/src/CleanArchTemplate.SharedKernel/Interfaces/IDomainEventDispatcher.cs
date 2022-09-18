// <copyright file="IDomainEventDispatcher.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>


namespace CleanArchTemplate.SharedKernel.Interfaces;

public interface IDomainEventDispatcher
{
    Task DispatchAndClearEvents(IEnumerable<EntityBase> entitiesWithEvents);
}
