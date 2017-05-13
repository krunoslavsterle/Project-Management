using PM.Model.Common;
using System;
using System.Collections.Generic;

namespace PM.Web.Administration.Task
{
    public class ListViewModel
    {
        public string ProjectName { get; set; }
        public Guid ProjectId { get; set; }

        public IEnumerable<TaskDTO> Tasks { get; set; }

        public Dictionary<Guid, string> TaskPriorityList { get; set; }
        public Dictionary<Guid, string> TaskStatusList { get; set; }
        public Dictionary<Guid, string> ProjectUsersList { get; set; }
    }
}
