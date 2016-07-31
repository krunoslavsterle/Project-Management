using PM.DAL.Entities;
using PM.Repository.Common;
using System.Threading.Tasks;

namespace PM.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> FindByUserNameAsync(string username);
    }
}