using System;

namespace PM.Web.Administration.User
{
    /// <summary>
    /// UserPreviewViewModel class.
    /// </summary>
    public class UserPreviewViewModel
    {
        public Guid UserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

    }
}
