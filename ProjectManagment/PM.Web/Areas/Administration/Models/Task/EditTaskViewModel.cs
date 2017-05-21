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

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        #endregion Model Properties

    }
}
