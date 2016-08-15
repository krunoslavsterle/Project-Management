using PM.Common;
using PM.DAL;
using PM.DAL.Entities;
using PM.Model;
using PM.Model.Common;
using PM.Repository.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace PM.Repository.Identity
{
    internal class ExternalLoginRepository : Repository<ExternalLoginEntity>, IExternalLoginRepository
    {
        #region Constructors

        internal ExternalLoginRepository(PMAppContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets the by provider and key asynchronous.
        /// </summary>
        /// <param name="loginProvider">The login provider.</param>
        /// <param name="providerKey">The provider key.</param>
        /// <returns></returns>
        public async Task<IExternalLogin> GetByProviderAndKeyAsync(string loginProvider, string providerKey)
        {
            var entity = await GetAsync(x => x.LoginProvider == loginProvider && x.ProviderKey == providerKey);
            return Mapper.Map<IExternalLogin>(entity);
        }

        /// <summary>
        /// Adds the <see cref="IExternalLogin"/> asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task.</returns>
        public Task AddAsync(IExternalLogin model)
        {
            var entity = Mapper.Map<ExternalLoginEntity>(model);
            return Task.FromResult(DbSet.Add(entity));
        }

        /// <summary>
        /// Asynchronously deletes <see cref="IExternalLogin"/> form the database.
        /// </summary>
        /// <param name="model">Model.</param>
        public Task DeleteAsync(IExternalLogin model)
        {
            var entity = Mapper.Map<ExternalLoginEntity>(model);
            DbSet.Remove(entity);
            return Task.FromResult(true);
        }

        /// <summary>
        /// Creates <see cref="IExternalLogin"/> the asynchronous.
        /// </summary>
        /// <returns><see cref="IExternalLogin"/>.</returns>
        public Task<IExternalLogin> CreateAsync()
        {
            IExternalLogin model = new ExternalLogin();
            return Task.FromResult(model);
        }

        /// <summary>
        /// Asynchronously updates entity in the database.
        /// </summary>
        /// <param name="entity">Entity.</param>
        public Task UpdateAsync(IExternalLogin model)
        {
            var entity = Mapper.Map<ExternalLoginEntity>(model);
            DbSet.Attach(entity);
            ((IObjectContextAdapter)Context).ObjectContext.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
            return Task.FromResult(true);
        }

        #endregion Methods
    }
}
