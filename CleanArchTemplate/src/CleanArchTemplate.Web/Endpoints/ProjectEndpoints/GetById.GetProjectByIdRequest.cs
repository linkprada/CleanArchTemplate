﻿// <copyright file="GetById.GetProjectByIdRequest.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

namespace CleanArchTemplate.Web.Endpoints.ProjectEndpoints
{
    public class GetProjectByIdRequest
    {
        public const string Route = "/Projects/{ProjectId:int}";
        public static string BuildRoute(int projectId) => Route.Replace("{ProjectId:int}", projectId.ToString());

        public int ProjectId { get; set; }
    }
}
