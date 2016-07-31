using PM.DAL.Entities;
using System.Threading.Tasks;

namespace PM.Repository.Common
{
    public interface IExternalLoginRepository : IRepository<ExternalLogin>
    {
        Task<ExternalLogin> GetByProviderAndKeyAsync(string loginProvider, string providerKey);
    }
}
