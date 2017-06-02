using PM.Model.Common;
using System;
using System.Collections.Generic;

namespace PM.Model
{
    /// <summary>
    /// Task poco class.
    /// </summary>
    public class TaskPoco : BasePoco, ITaskPoco
    {
        #region Properties
        
        /// <summary>
        /// Gets or sets the project identifier.
        /// </summary>
        /// <value>
        /// The project identifier.
        /// </value>
        public Guid ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the created by user identifier.
        /// </summary>
        /// <value>
        /// The created by user identifier.
        /// </value>
        public Guid CreatedByUserId { get; set; }

        /// <summary>
        /// Gets or sets the assigned to user identifier.
        /// </summary>
        /// <value>
        /// The assigned to user identifier.
        /// </value>
        public Guid AssignedToUserId { get; set; }

        /// <summary>
        /// Gets or sets the status identifier.
        /// </summary>
        /// <value>
        /// The status identifier.
        /// </value>
        public Guid StatusId { get; set; }

        /// <summary>
        /// Gets or sets the priority identifier.
        /// </summary>
        /// <value>
        /// The priority identifier.
        /// </value>
        public Guid PriorityId { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the due date.
        /// </summary>
        /// <value>
        /// The due date.
        /// </value>
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// Gets or sets the progress.
        /// </summary>
        /// <value>
        /// The progress.
        /// </value>
        public byte Progress { get; set; }
                
        #endregion Properties

        #region Navigation Properties

        /// <summary>
        /// Gets or sets the project navigation property.
        /// </summary>
        /// <value>
        /// The project.
        /// </value>
        public virtual IProjectPoco Project { get; set; }

        /// <summary>
        /// Gets or sets the assigned to user navigation property.
        /// </summary>
        /// <value>
        /// The assigned to user.
        /// </value>
        public virtual IUserPoco AssignedToUser { get; set; }

        /// <summary>
        /// Gets or sets the created by user navigation property.
        /// </summary>
        /// <value>
        /// The created by user.
        /// </value>
        public virtual IUserPoco CreatedByUser { get; set; }

        /// <summary>
        /// Gets or sets the task priority navigation property.
        /// </summary>
        /// <value>
        /// The task priority.
        /// </value>
        public virtual ITaskPriorityPoco TaskPriority { get; set; }

        /// <summary>
        /// Gets or sets the task status navigation property.
        /// </summary>
        /// <value>
        /// The task status.
        /// </value>
        public virtual ITaskStatusPoco TaskStatus { get; set; }

        /// <summary>
        /// Gets or sets the task comments.
        /// </summary>
        /// <value>
        /// The task comments.
        /// </value>
        public virtual IEnumerable<ITaskCommentPoco> TaskComments { get; set; }

        #endregion Navigation Properties
    }
}
