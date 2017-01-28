using PM.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.Web.Areas.Administration.Models
{
    public class TaskViewModel
    {
        public Guid ProjectId { get; set; }

        public IEnumerable<ITaskPoco> Tasks { get; set; }
    }
}
