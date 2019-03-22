using PM.Model.Common;
using System;

namespace PM.Model
{
    /// <summary>
    /// TaskComment poco class.
    /// </summary>
    /// <seealso cref="PM.Model.BasePoco" />
    public class TaskCommentPoco : BasePoco, ITaskCommentPoco
    {
        #region Properties

        /// <summary>
        /// Gets or sets the task identifier.
        /// </summary>
        /// <value>
        /// The task identifier.
        /// </value>
        public Guid TaskId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public Guid UserId { get; set; }
        
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text { get; set; }

        #endregion Properties

        #region Navigation Properties

        /// <summary>
        /// Gets or sets the task navigation propertie.
        /// </summary>
        /// <value>
        /// The task.
        /// </value>
        public virtual ITaskPoco Task { get; set; }

        /// <summary>
        /// Gets or sets the user navigation propertie.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public virtual IUserPoco User { get; set; }

        #endregion Navigation Properties
    }
}
