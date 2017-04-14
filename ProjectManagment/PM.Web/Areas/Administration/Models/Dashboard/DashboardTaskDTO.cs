using System;

namespace PM.Web.Areas.Administration.Models
{
    public class DashboardTaskDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Project { get; set; }
        public string Status { get; set; }
        public DateTime DueDate { get; set; }
    }
}
