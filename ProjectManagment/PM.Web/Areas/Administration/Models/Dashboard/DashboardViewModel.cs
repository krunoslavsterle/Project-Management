using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        // List of tasks

    }
}
