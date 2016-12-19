using Microsoft.AspNet.Identity;
using PM.Common;
using PM.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.Web.Identity
{
    public class RoleStore : IRoleStore<IdentityRole, Guid>, IQueryableRoleStore<IdentityRole, Guid>, IDisposable
    {
        private readonly IIdentityService identityService;
        private readonly IMapper mapper;

        public RoleStore(IIdentityService identityService, IMapper mapper)
        {
            this.identityService = identityService;
            this.mapper = mapper;
        }

        #region IRolePocoStore<IdentityRole, Guid> Members
        public Task CreateAsync(IdentityRole role)
        {
            if (role == null)
                throw new ArgumentNullException("role");

            var model = mapper.Map<PM.Model.Common.IRolePoco>(role);

            return identityService.AddRoleAsync(model);
        }

        public System.Threading.Tasks.Task DeleteAsync(IdentityRole role)
        {
            if (role == null)
                throw new ArgumentNullException("role");

            var model = mapper.Map<PM.Model.Common.IRolePoco>(role);
            return identityService.DeleteRoleAsync(model);
        }

        public async System.Threading.Tasks.Task<IdentityRole> FindByIdAsync(Guid roleId)
        {
            var role = await identityService.GetRoleAsync(roleId);
            return mapper.Map<IdentityRole>(role);
        }

        public async System.Threading.Tasks.Task<IdentityRole> FindByNameAsync(string roleName)
        {
            var role = await identityService.GetRoleAsync(roleName);
            return mapper.Map<IdentityRole>(role);
        }

        public System.Threading.Tasks.Task UpdateAsync(IdentityRole role)
        {
            if (role == null)
                throw new ArgumentNullException("role");

            var model = mapper.Map<PM.Model.Common.IRolePoco>(role);
            return identityService.UpdateRoleAsync(model);
        }
        #endregion

        #region IDisposable Members
        public void Dispose()
        {
            // Dispose does nothing since we want Unity to manage the lifecycle of our Unit of Work
        }
        #endregion

        #region IQueryableRoleStore<IdentityRole, Guid> Members
        public IQueryable<IdentityRole> Roles
        {
            get
            {
                var roles = identityService.GetAllRoles();
                return mapper.Map<IList<IdentityRole>>(roles).AsQueryable();
            }
        }
        #endregion
        
    }
}
