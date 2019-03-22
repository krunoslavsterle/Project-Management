using System;


namespace PM.Model.Common
{
    /// <summary>
    /// TaskCommentPoco contract.
    /// </summary>
    /// <seealso cref="PM.Model.Common.IBasePoco" />
    public interface ITaskCommentPoco : IBasePoco
    {
        #region Properties

        /// <summary>
        /// Gets or sets the task identifier.
        /// </summary>
        /// <value>
        /// The task identifier.
        /// </value>
        Guid TaskId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        string Text { get; set; }

        #endregion Properties

        #region Navigation Properties

        /// <summary>
        /// Gets or sets the task navigation propertie.
        /// </summary>
        /// <value>
        /// The task.
        /// </value>
        ITaskPoco Task { get; set; }

        /// <summary>
        /// Gets or sets the user navigation propertie.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        IUserPoco User { get; set; }

        #endregion Navigation Properties
    }
}
