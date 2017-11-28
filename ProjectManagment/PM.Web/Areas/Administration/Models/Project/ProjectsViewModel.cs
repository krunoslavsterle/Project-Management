using PagedList;
using System.Collections.Generic;

namespace PM.Web.Administration.Project
{
    public class ProjectsViewModel
    {
        public IPagedList<ProjectPreviewViewModel> Projects { get; set; }
    }
}
