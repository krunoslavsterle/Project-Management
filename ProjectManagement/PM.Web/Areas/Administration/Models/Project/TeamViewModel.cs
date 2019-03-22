using PM.Web.Administration.User;
using System;
using System.Collections.Generic;
using PagedList;

namespace PM.Web.Administration.Project
{
    public class TeamViewModel
    {
        public string ProjectName { get; set; }
        public Guid ProjectId { get; set; }
        public Guid SelectedUserId { get; set; }
        public Guid SelectedProjectRoleId { get; set; }

        public IPagedList<UserPreviewViewModel> ProjectUsers { get; set; }
    }
}
