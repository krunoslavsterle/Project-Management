using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PM.Common;
using PM.Service.Common;

namespace PM.Web.Identity
{
    public class UserStore : IUserLoginStore<IdentityUser, Guid>, IUserClaimStore<IdentityUser, Guid>, IUserRoleStore<IdentityUser, Guid>, IUserPasswordStore<IdentityUser, Guid>, IUserSecurityStampStore<IdentityUser, Guid>, IUserStore<IdentityUser, Guid>, IDisposable
    {
        private readonly IMapper mapper;
        private readonly IIdentityService identityService;
        
        public UserStore(IIdentityService identityService, IMapper mapper)
        {
            this.identityService = identityService;
            this.mapper = mapper;
        }

        #region IUserPocoStore<IdentityUser, Guid> Members

        public Task CreateAsync(IdentityUser user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            var model = mapper.Map<PM.Model.Common.IUserPoco>(user);
            return identityService.AddUserAsync(model);
        }

        public Task DeleteAsync(IdentityUser user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            var model = mapper.Map<PM.Model.Common.IUserPoco>(user);
            return identityService.DeleteUserAsync(model);
        }

        public async Task<IdentityUser> FindByIdAsync(Guid userId)
        {
            var model = await identityService.GetUserById(userId);
            return mapper.Map<IdentityUser>(model);
        }

        public async Task<IdentityUser> FindByNameAsync(string userName)
        {
            var user = await identityService.GetUserByUserNameAsync(userName);
            return mapper.Map<IdentityUser>(user);
        }

        public async Task UpdateAsync(IdentityUser user)
        {
            if (user == null)
                throw new ArgumentException("user");

            var u = await identityService.GetUserById(user.Id);
            
            if (u == null)
                throw new ArgumentException("IdentityUser does not correspond to a User entity.", "user");

            u = this.mapper.Map<PM.Model.Common.IUserPoco>(user);
            await identityService.UpdateUserAsync(u);
        }

        #endregion

        #region IDisposable Members
        public void Dispose()
        {
            // Dispose does nothing since we want Unity to manage the lifecycle of our Unit of Work
        }
        #endregion

        #region IUserPocoClaimStore<IdentityUser, Guid> Members

        public async Task AddClaimAsync(IdentityUser user, System.Security.Claims.Claim claim)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            if (claim == null)
                throw new ArgumentNullException("claim");

            var u = await identityService.GetUserById(user.Id);
            if (u == null)
                throw new ArgumentException("IdentityUser does not correspond to a User entity.", "user");

            var c = await identityService.CreateClaimAsync();
            c.ClaimType = claim.Type;
            c.ClaimValue = claim.Value;
            c.User = u;

            u.Claims.Add(c);
            await identityService.UpdateUserAsync(u);
        }

        public async Task<IList<System.Security.Claims.Claim>> GetClaimsAsync(IdentityUser user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            var u = await identityService.GetUserById(user.Id);
            if (u == null)
                throw new ArgumentException("IdentityUser does not correspond to a User entity.", "user");

            return u.Claims.Select(x => new System.Security.Claims.Claim(x.ClaimType, x.ClaimValue)).ToList();
        }

        public async Task RemoveClaimAsync(IdentityUser user, System.Security.Claims.Claim claim)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            if (claim == null)
                throw new ArgumentNullException("claim");

            var u = await identityService.GetUserById(user.Id);
            if (u == null)
                throw new ArgumentException("IdentityUser does not correspond to a User entity.", "user");

            var c = u.Claims.FirstOrDefault(x => x.ClaimType == claim.Type && x.ClaimValue == claim.Value);
            u.Claims.Remove(c);

            await identityService.UpdateUserAsync(u);
        }

        #endregion

        #region IUserPocoLoginStore<IdentityUser, Guid> Members

        public async Task AddLoginAsync(IdentityUser user, UserLoginInfo login)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            if (login == null)
                throw new ArgumentNullException("login");

            var u = await identityService.GetUserById(user.Id);
            if (u == null)
                throw new ArgumentException("IdentityUser does not correspond to a User entity.", "user");

            var l = await identityService.CreateExternalLoginAsync();
            l.LoginProvider = login.LoginProvider;
            l.ProviderKey = login.ProviderKey;
            l.User = u;

            u.ExternalLogins.Add(l);
            await identityService.UpdateUserAsync(u);
        }

        public async Task<IdentityUser> FindAsync(UserLoginInfo login)
        {
            if (login == null)
                throw new ArgumentNullException("login");

            var identityUser = default(IdentityUser);

            var l = await identityService.GetExternalLoginAsync(login.LoginProvider, login.ProviderKey);
            if (l != null)
                identityUser = mapper.Map<IdentityUser>(l.User);

            return identityUser;
        }

        public async Task<IList<UserLoginInfo>> GetLoginsAsync(IdentityUser user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            var u = await identityService.GetUserById(user.Id);
            if (u == null)
                throw new ArgumentException("IdentityUser does not correspond to a User entity.", "user");

            return u.ExternalLogins.Select(x => new UserLoginInfo(x.LoginProvider, x.ProviderKey)).ToList();
        }

        public async Task RemoveLoginAsync(IdentityUser user, UserLoginInfo login)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            if (login == null)
                throw new ArgumentNullException("login");

            var u = await identityService.GetUserById(user.Id);
            if (u == null)
                throw new ArgumentException("IdentityUser does not correspond to a User entity.", "user");

            var l = u.ExternalLogins.FirstOrDefault(x => x.LoginProvider == login.LoginProvider && x.ProviderKey == login.ProviderKey);
            u.ExternalLogins.Remove(l);

            await identityService.UpdateUserAsync(u);
        }

        #endregion

        #region IUserPocoRoleStore<IdentityUser, Guid> Members
        public async Task AddToRoleAsync(IdentityUser user, string roleName)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            if (string.IsNullOrWhiteSpace(roleName))
                throw new ArgumentException("Argument cannot be null, empty, or whitespace: roleName.");

            var u = await identityService.GetUserById(user.Id);
            if (u == null)
                throw new ArgumentException("IdentityUser does not correspond to a User entity.", "user");
            var r = await identityService.GetRoleAsync(roleName);
            if (r == null)
                throw new ArgumentException("roleName does not correspond to a Role entity.", "roleName");

            var userRole = identityService.CreateUserRole();
            userRole.Id = Guid.NewGuid();
            userRole.RoleId = r.RoleId;
            userRole.UserId = user.Id;

            await identityService.InsertUserRole(userRole);
        }

        public async Task<IList<string>> GetRolesAsync(IdentityUser user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            var u = await identityService.GetUserById(user.Id);
            if (u == null)
                throw new ArgumentException("IdentityUser does not correspond to a User entity.", "user");

            //return u.Roles.Select(x => x.Name).ToList();
            return null;
        }

        public async Task<bool> IsInRoleAsync(IdentityUser user, string roleName)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            if (string.IsNullOrWhiteSpace(roleName))
                throw new ArgumentException("Argument cannot be null, empty, or whitespace: role.");

            var u = await identityService.GetUserById(user.Id);
            if (u == null)
                throw new ArgumentException("IdentityUser does not correspond to a User entity.", "user");

            //return u.Roles.Any(x => x.Name == roleName);

            return false;
        }

        public async Task RemoveFromRoleAsync(IdentityUser user, string roleName)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            if (string.IsNullOrWhiteSpace(roleName))
                throw new ArgumentException("Argument cannot be null, empty, or whitespace: role.");

            var u = await identityService.GetUserById(user.Id);
            if (u == null)
                throw new ArgumentException("IdentityUser does not correspond to a User entity.", "user");

            //var r = u.Roles.FirstOrDefault(x => x.Name == roleName);
            //u.Roles.Remove(r);

            await identityService.UpdateUserAsync(u);
        }
        #endregion

        #region IUserPocoPasswordStore<IdentityUser, Guid> Members

        public Task<string> GetPasswordHashAsync(IdentityUser user)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            return Task.FromResult<string>(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(IdentityUser user)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            return Task.FromResult<bool>(!string.IsNullOrWhiteSpace(user.PasswordHash));
        }

        public Task SetPasswordHashAsync(IdentityUser user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            return Task.FromResult(0);
        }

        #endregion

        #region IUserPocoSecurityStampStore<IdentityUser, Guid> Members

        public Task<string> GetSecurityStampAsync(IdentityUser user)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            return Task.FromResult<string>(user.SecurityStamp);
        }

        public Task SetSecurityStampAsync(IdentityUser user, string stamp)
        {
            user.SecurityStamp = stamp;
            return Task.FromResult(0);
        }

        #endregion
    }
}
