using System;
using System.Collections.Generic;
using PagedList;

namespace PM.Web.Administration.Task
{
    public class ListViewModel
    {
        public string ProjectName { get; set; }
        public Guid ProjectId { get; set; }

        public IPagedList<TaskDTO> Tasks { get; set; }

        public Dictionary<Guid, string> TaskPriorityList { get; set; }
        public Dictionary<Guid, string> TaskStatusList { get; set; }
        public Dictionary<Guid, string> ProjectUsersList { get; set; }
    }
}
