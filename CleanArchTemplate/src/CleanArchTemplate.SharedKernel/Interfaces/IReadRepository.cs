// <copyright file="IReadRepository.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using Ardalis.Specification;

namespace CleanArchTemplate.SharedKernel.Interfaces;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}
