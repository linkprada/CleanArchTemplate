﻿// <copyright file="IgnoreMemberAttribute.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

namespace CleanArchTemplate.SharedKernel;

// source: https://github.com/jhewlett/ValueObject
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class IgnoreMemberAttribute : Attribute
{
}
