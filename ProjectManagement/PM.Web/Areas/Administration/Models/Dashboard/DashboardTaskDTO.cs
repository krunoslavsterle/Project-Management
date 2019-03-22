using System;
using System.Collections.Generic;

namespace PM.Web.Areas.Administration.Models
{
    public class DashboardTaskDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ProjectName { get; set; }
        public Guid StatusId { get; set; }
        public DateTime? DueDate { get; set; }        
    }
}
