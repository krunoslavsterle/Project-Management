using System;

namespace PM.Web.Administration.Task
{
    public class TaskDTO
    {
        public Guid Id { get; set; }
        public Guid PriorityId { get; set; }
        public Guid AssignedToId { get; set; }

        public string Title { get; set; }
        public string AssignedToUsername { get; set; }

        public byte Progress { get; set; }
        public int CommentsCount { get; set; }

        public DateTime? DueDate { get; set; }
    }
}
