using PM.Web.Administration.User;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PM.Web.Administration.Project
{
    public class TeamViewModel
    {
        public Guid Projectid { get; set; }

        public Guid SelectedUserId { get; set; }

        public IEnumerable<UserPreviewViewModel> ProjectUsers { get; set; }

        public SelectList OptionalUsers { get; set; }
    }
}
