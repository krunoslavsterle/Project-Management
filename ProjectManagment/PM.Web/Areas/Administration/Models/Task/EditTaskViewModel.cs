using System;
using System.ComponentModel.DataAnnotations;

namespace PM.Web.Administration.Task
{
    /// <summary>
    /// Edit Task view model.
    /// </summary>
    public class EditTaskViewModel : CreateTaskViewModel
    {
        #region Model Properties
        
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid CreatedByUserId { get; set; }

        [Required]
        public Guid StatusId { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateUpdated { get; set; }

        #endregion Model Properties

    }
}
