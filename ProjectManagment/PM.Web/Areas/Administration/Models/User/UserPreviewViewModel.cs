using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
