using System;
using System.Collections.Generic;

namespace PM.Model.Common
{
    public interface ITaskPoco : IBasePoco
    {
        #region Properties
        
        /// <summary>
        /// Gets or sets the project identifier.
        /// </summary>
        /// <value>
        /// The project identifier.
        /// </value>
        Guid ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the created by user identifier.
        /// </summary>
        /// <value>
        /// The created by user identifier.
        /// </value>
        Guid CreatedByUserId { get; set; }

        /// <summary>
        /// Gets or sets the assigned to user identifier.
        /// </summary>
        /// <value>
        /// The assigned to user identifier.
        /// </value>
        Guid AssignedToUserId { get; set; }

        /// <summary>
        /// Gets or sets the status identifier.
        /// </summary>
        /// <value>
        /// The status identifier.
        /// </value>
        Guid StatusId { get; set; }

        /// <summary>
        /// Gets or sets the priority identifier.
        /// </summary>
        /// <value>
        /// The priority identifier.
        /// </value>
        Guid PriorityId { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        string Title { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the due date.
        /// </summary>
        /// <value>
        /// The due date.
        /// </value>
        DateTime? DueDate { get; set; }

        /// <summary>
        /// Gets or sets the progress.
        /// </summary>
        /// <value>
        /// The progress.
        /// </value>
        byte Progress { get; set; }
                
        #endregion Properties

        #region Navigation Properties

        /// <summary>
        /// Gets or sets the project navigation property.
        /// </summary>
        /// <value>
        /// The project.
        /// </value>
        IProjectPoco Project { get; set; }

        /// <summary>
        /// Gets or sets the assigned to user navigation property.
        /// </summary>
        /// <value>
        /// The assigned to user.
        /// </value>
        IUserPoco AssignedToUser { get; set; }

        /// <summary>
        /// Gets or sets the created by user navigation property.
        /// </summary>
        /// <value>
        /// The created by user.
        /// </value>
        IUserPoco CreatedByUser { get; set; }

        /// <summary>
        /// Gets or sets the task priority navigation property.
        /// </summary>
        /// <value>
        /// The task priority.
        /// </value>
        ITaskPriorityPoco TaskPriority { get; set; }

        /// <summary>
        /// Gets or sets the task status navigation property.
        /// </summary>
        /// <value>
        /// The task status.
        /// </value>
        ITaskStatusPoco TaskStatus { get; set; }

        /// <summary>
        /// Gets or sets the task comments.
        /// </summary>
        /// <value>
        /// The task comments.
        /// </value>
        IEnumerable<ITaskCommentPoco> TaskComments { get; set; }

        #endregion Navigation Properties
    }
}
