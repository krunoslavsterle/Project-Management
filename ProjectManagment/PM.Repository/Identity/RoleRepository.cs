using PM.DAL;
using PM.DAL.Entities;
using PM.Repository.Common;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PM.Repository.Identity
{
    internal class RoleRepository : Repository<Role>, IRoleRepository
    {
        internal RoleRepository(PMAppContext context)
            : base(context)
        {
        }

        public Task<Role> FindByIdAsync(Guid id)
        {
            return GetAsync(x => x.RoleId == id);
        }

        public Task<Role> FindByNameAsync(string roleName)
        {
            return GetAsync(x => x.Name == roleName);
        }        
    }
}
