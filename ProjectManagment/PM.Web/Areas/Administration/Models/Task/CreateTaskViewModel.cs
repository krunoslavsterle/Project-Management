using System;
using System.ComponentModel.DataAnnotations;

namespace PM.Web.Administration.Task
{
    /// <summary>
    /// Create task view model.
    /// </summary>
    public class CreateTaskViewModel
    {
        #region Model Properties

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
        /// Gets or sets the due date.
        /// </summary>
        /// <value>
        /// The due date.
        /// </value>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string DueDate { get; set; }
        
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
        
        #endregion Model Properties
        
    }
}
