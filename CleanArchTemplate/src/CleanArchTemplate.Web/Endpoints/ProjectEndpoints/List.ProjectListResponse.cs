using System.Collections.Generic;
using CleanArchTemplate.Core.ProjectAggregate;

namespace CleanArchTemplate.Web.Endpoints.ProjectEndpoints
{
    public class ProjectListResponse
    {
        public List<ProjectRecord> Projects { get; set; } = new();
    }
}
