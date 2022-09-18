// <copyright file="ErrorViewModel.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

namespace CleanArchTemplate.Web.ViewModels;

public class ErrorViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
