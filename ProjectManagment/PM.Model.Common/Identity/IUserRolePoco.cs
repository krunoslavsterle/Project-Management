using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.Model.Common
{
    public interface IUserRolePoco
    {
        Guid Id { get; set; }

        Guid UserId { get; set; }

        Guid RoleId { get; set; }

        IUserPoco User { get; set; }

        IRolePoco Role { get; set; }
    }
}
