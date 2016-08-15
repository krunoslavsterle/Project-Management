using System;
using System.ComponentModel.DataAnnotations;

namespace PM.Web.Areas.Administration.Models
{
    /// <summary>
    /// Create task view model.
    /// </summary>
    public class CreateTaskViewModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Required]
        public string Description { get; set; }
        
        /// <summary>
        /// Gets or sets the assigned user identifier.
        /// </summary>
        /// <value>
        /// The assigned user identifier.
        /// </value>
        [Required]
        public Guid AssignedUserId { get; set; }

        /// <summary>
        /// Gets or sets the project id.
        /// </summary>
        /// <value>
        /// The project id.
        /// </value>
        [Required]
        public Guid ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the owner id.
        /// </summary>
        /// <value>The owner id.</value>
        public Guid OwnerId { get; set; }
    }
}
