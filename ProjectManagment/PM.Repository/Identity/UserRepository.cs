using PM.DAL.Entities;
using PM.DAL;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace PM.Repository
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
        internal UserRepository(PMAppContext context)
            : base(context)
        {
        }
        
        public Task<User> FindByUserNameAsync(string username)
        {
            return GetAsync(x => x.UserName == username);
        }		
    }
}