using PM.DAL.Entities;
using System;
using System.Threading.Tasks;

namespace PM.Repository.Common
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<Role> FindByNameAsync(string roleName);

        Task<Role> FindByIdAsync(Guid id);
    }
}
