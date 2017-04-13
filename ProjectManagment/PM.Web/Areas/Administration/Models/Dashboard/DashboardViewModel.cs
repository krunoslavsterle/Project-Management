using System.Collections.Generic;

namespace PM.Web.Areas.Administration.Models
{
    /// <summary>
    /// Dashboard view model.
    /// </summary>
    public class DashboardViewModel
    {
        public string UserName { get; set; }
        public string UserTitle { get; set; }
        public int NumOfProjects { get; set; }
        public int NumOfTasks { get; set; }

        // List of activities
        public IEnumerable<DashboardActivityDTO> Activities { get; set; }

        // List of tasks

    }
}
