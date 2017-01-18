using PM.Common;
using PM.DAL;
using PM.Model.Common;
using PM.Repository.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace PM.Repository.Identity
{
    internal class ExternalLoginRepository : GenericRepository<ExternalLogin, IExternalLoginPoco>, IExternalLoginRepository
    {
        #region Constructors

        internal ExternalLoginRepository(PMDatabaseEntities context, IMapper mapper)
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
        public async System.Threading.Tasks.Task<IExternalLoginPoco> GetByProviderAndKeyAsync(string loginProvider, string providerKey)
        {
            var entity = await GetOneAsync(x => x.LoginProvider == loginProvider && x.ProviderKey == providerKey);
            return mapper.Map<IExternalLoginPoco>(entity);
        }

        /// <summary>
        /// Adds the <see cref="IExternalLoginPoco"/> asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>System.Threading.Tasks.Task.</returns>
        public System.Threading.Tasks.Task AddAsync(IExternalLoginPoco model)
        {
            var entity = mapper.Map<ExternalLogin>(model);
            return System.Threading.Tasks.Task.FromResult(dbSet.Add(entity));
        }

        /// <summary>
        /// Asynchronously deletes <see cref="IExternalLoginPoco"/> form the database.
        /// </summary>
        /// <param name="model">Model.</param>
        public System.Threading.Tasks.Task DeleteAsync(IExternalLoginPoco model)
        {
            var entity = mapper.Map<ExternalLogin>(model);
            dbSet.Remove(entity);
            return System.Threading.Tasks.Task.FromResult(true);
        }

        /// <summary>
        /// Creates <see cref="IExternalLoginPoco"/> the asynchronous.
        /// </summary>
        /// <returns><see cref="IExternalLoginPoco"/>.</returns>
        public System.Threading.Tasks.Task<IExternalLoginPoco> CreateAsync()
        {
            IExternalLoginPoco model = new Model.ExternalLoginPoco();
            return System.Threading.Tasks.Task.FromResult(model);
        }

        /// <summary>
        /// Asynchronously updates entity in the database.
        /// </summary>
        /// <param name="entity">Entity.</param>
        public System.Threading.Tasks.Task UpdateAsync(IExternalLoginPoco model)
        {
            var entity = mapper.Map<ExternalLogin>(model);
            dbSet.Attach(entity);
            ((IObjectContextAdapter)context).ObjectContext.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
            return System.Threading.Tasks.Task.FromResult(true);
        }

        #endregion Methods
    }
}
