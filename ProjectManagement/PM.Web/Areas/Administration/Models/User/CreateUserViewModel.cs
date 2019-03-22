using System.ComponentModel.DataAnnotations;

namespace PM.Web.Administration.User
{
    /// <summary>
    /// Create User view model.
    /// </summary>
    public class CreateUserViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

    }
}
