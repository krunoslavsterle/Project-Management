using PM.DAL;
using PM.DAL.Entities;
using PM.Repository.Common;
using System.Threading.Tasks;

namespace PM.Repository.Identity
{
    internal class ExternalLoginRepository : Repository<ExternalLogin>, IExternalLoginRepository
    {
        internal ExternalLoginRepository(PMAppContext context)
            : base(context)
        {
        }

        public Task<ExternalLogin> GetByProviderAndKeyAsync(string loginProvider, string providerKey)
        {
            return GetAsync(x => x.LoginProvider == loginProvider && x.ProviderKey == providerKey);
        }
    }
}
