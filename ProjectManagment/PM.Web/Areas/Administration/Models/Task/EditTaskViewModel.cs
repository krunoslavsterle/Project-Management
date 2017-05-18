using System;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PM.Web.Administration.Task
{
    /// <summary>
    /// Edit Task view model.
    /// </summary>
    public class EditTaskViewModel
    {
        #region Model Properties

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the status identifier.
        /// </summary>
        /// <value>
        /// The status identifier.
        /// </value>
        [Required]
        public Guid StatusId { get; set; }

        /// <summary>
        /// Gets or sets the priority identifier.
        /// </summary>
        /// <value>
        /// The priority identifier.
        /// </value>
        [Required]
        public Guid PriorityId { get; set; }

        /// <summary>
        /// Gets or sets the assigned user identifier.
        /// </summary>
        /// <value>
        /// The assigned user identifier.
        /// </value>
        public Guid AssignedToUserId { get; set; }

        /// <summary>
        /// Gets or sets the project id.
        /// </summary>
        /// <value>
        /// The project id.
        /// </value>
        public Guid ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the owner id.
        /// </summary>
        /// <value>The owner id.</value>
        public Guid CreatedByUserId { get; set; }

        #endregion Model Properties

        #region View Properties

        /// <summary>
        /// Gets or sets the status list.
        /// </summary>
        /// <value>
        /// The status list.
        /// </value>
        public SelectList StatusList { get; set; }

        /// <summary>
        /// Gets or sets the priority list.
        /// </summary>
        /// <value>
        /// The priority list.
        /// </value>
        public SelectList PriorityList { get; set; }

        #endregion View Properties
    }
}
