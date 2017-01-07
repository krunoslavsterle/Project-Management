using PM.DAL;
using PM.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using PM.Model.Common;
using PM.Common;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace PM.Repository.Identity
{
    internal class RoleRepository : GenericRepository<Role>, IRoleRepository
    {       
        internal RoleRepository(PMDatabaseEntities context, IMapper mapper)
            : base(context, mapper)
        {
        }


        /// <summary>
        /// Finds the by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async System.Threading.Tasks.Task<IRolePoco> FindByIdAsync(Guid id)
        {
            var entity = await GetOneAsync(x => x.RoleId == id);
            return mapper.Map<IRolePoco>(entity);
        }

        /// <summary>
        /// Finds the by name asynchronous.
        /// </summary>
        /// <param name="roleName">Name of the role.</param>
        /// <returns></returns>
        public async System.Threading.Tasks.Task<IRolePoco> FindByNameAsync(string roleName)
        {
            var entity = await GetOneAsync(x => x.Name == roleName);
            return mapper.Map<IRolePoco>(entity);
        }

        /// <summary>
        /// Adds the <see cref="IRole"/> asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>System.Threading.Tasks.Task.</returns>
        public System.Threading.Tasks.Task AddAsync(IRolePoco model)
        {
            var entity = mapper.Map<Role>(model);
            return System.Threading.Tasks.Task.FromResult(dbSet.Add(entity));
        }

        /// <summary>
        /// Asynchronously deletes <see cref="IUser"/> form the database.
        /// </summary>
        /// <param name="model">Model.</param>
        public System.Threading.Tasks.Task DeleteAsync(IRolePoco model)
        {
            var entity = mapper.Map<Role>(model);
            dbSet.Remove(entity);
            return System.Threading.Tasks.Task.FromResult(true);
        }

        /// <summary>
        /// Asynchronously updates entity in the database.
        /// </summary>
        /// <param name="entity">Entity.</param>
        public System.Threading.Tasks.Task UpdateAsync(IRolePoco model)
        {
            var entity = mapper.Map<Role>(model);
            dbSet.Attach(entity);
            ((IObjectContextAdapter)context).ObjectContext.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
            return System.Threading.Tasks.Task.FromResult(true);
        }

        /// <summary>
        /// Gets all records.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Enumerable list of records.</returns>
        public IList<IRolePoco> GetAll()
        {
            var entities = dbSet.ToList();
            return mapper.Map<IList<IRolePoco>>(entities);
        }
    }
}
