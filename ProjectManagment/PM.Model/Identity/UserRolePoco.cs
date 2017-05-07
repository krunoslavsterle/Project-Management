using PM.Model.Common;
using System;

namespace PM.Model
{
    public class UserRolePoco : IUserRolePoco
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid RoleId { get; set; }

        public IUserPoco User { get; set; }

        public IRolePoco Role { get; set; }
    }
}
