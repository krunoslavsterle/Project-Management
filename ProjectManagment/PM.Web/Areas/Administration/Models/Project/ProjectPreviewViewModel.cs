using PM.Web.Administration.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.Web.Administration.Project
{
    public class ProjectPreviewViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int TaskCount { get; set; }

        public int CompletedTaskCount { get; set; }

        public int LateTaskCount { get; set; }

        public IEnumerable<UserPreviewViewModel> TeamMembers { get; set; }
    }
}
