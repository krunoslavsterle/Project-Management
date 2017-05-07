using PM.Model.Common;
using System.Collections.Generic;

namespace PM.Web.Administration.User
{
    public class IndexUserViewModel
    {
        public IEnumerable<UserPreviewViewModel> Users { get; set; }
    }
}
