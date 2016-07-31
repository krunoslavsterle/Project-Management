using Microsoft.AspNet.Identity;
using PM.DAL.Entities;
using PM.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.Web.Identity
{
    public class RoleStore : IRoleStore<IdentityRole, Guid>, IQueryableRoleStore<IdentityRole, Guid>, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleStore(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region IRoleStore<IdentityRole, Guid> Members
        public Task CreateAsync(IdentityRole role)
        {
            if (role == null)
                throw new ArgumentNullException("role");

            var r = getRole(role);

            _unitOfWork.RoleRepository.AddAsync(r);
            return _unitOfWork.SaveChangesAsync();
        }

        public System.Threading.Tasks.Task DeleteAsync(IdentityRole role)
        {
            if (role == null)
                throw new ArgumentNullException("role");

            var r = getRole(role);

            _unitOfWork.RoleRepository.DeleteAsync(r);
            return _unitOfWork.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task<IdentityRole> FindByIdAsync(Guid roleId)
        {
            var role = await _unitOfWork.RoleRepository.FindByIdAsync(roleId);
            return getIdentityRole(role);
        }

        public async System.Threading.Tasks.Task<IdentityRole> FindByNameAsync(string roleName)
        {
            var role = await _unitOfWork.RoleRepository.FindByNameAsync(roleName);
            return getIdentityRole(role);
        }

        public System.Threading.Tasks.Task UpdateAsync(IdentityRole role)
        {
            if (role == null)
                throw new ArgumentNullException("role");
            var r = getRole(role);
            _unitOfWork.RoleRepository.UpdateAsync(r);
            return _unitOfWork.SaveChangesAsync();
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
                return _unitOfWork.RoleRepository
                    .GetAll()
                    .Select(x => getIdentityRole(x))
                    .AsQueryable();
            }
        }
        #endregion

        #region Private Methods
        private Role getRole(IdentityRole identityRole)
        {
            if (identityRole == null)
                return null;
            return new Role
            {
                RoleId = identityRole.Id,
                Name = identityRole.Name
            };
        }

        private IdentityRole getIdentityRole(Role role)
        {
            if (role == null)
                return null;
            return new IdentityRole
            {
                Id = role.RoleId,
                Name = role.Name
            };
        }
        #endregion
    }
}
