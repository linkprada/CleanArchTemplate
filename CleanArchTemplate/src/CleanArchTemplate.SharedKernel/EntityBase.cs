// <copyright file="EntityBase.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchTemplate.SharedKernel;

// This can be modified to EntityBase<TId> to support multiple key types (e.g. Guid)
public abstract class EntityBase
{
    public int Id { get; set; }
}
