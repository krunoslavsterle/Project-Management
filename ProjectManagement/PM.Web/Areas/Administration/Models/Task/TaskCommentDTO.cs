using System;
using System.ComponentModel.DataAnnotations;

namespace PM.Web.Administration.Task
{
    public class TaskCommentDTO
    {
        #region Constructors

        public TaskCommentDTO()
        {
        }

        public TaskCommentDTO(Guid taskId)
        {
            this.TaskId = taskId;
        }

        #endregion Constructors

        #region Properties

        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        [Required]
        public Guid TaskId { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime DateUpdated { get; set; }

        #endregion Properties
    }
}
