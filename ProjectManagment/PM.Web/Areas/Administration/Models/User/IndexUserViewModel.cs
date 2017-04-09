using PM.Model.Common;
using System.Collections.Generic;

namespace PM.Web.Administration.Models
{
    public class IndexUserViewModel
    {
        public IEnumerable<IUserPoco> Users { get; set; }
    }
}
