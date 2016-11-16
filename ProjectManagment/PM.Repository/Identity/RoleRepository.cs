using PM.DAL;
using PM.Repository.Common;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using PM.Model.Common;
using PM.Common;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace PM.Repository.Identity
{
    internal class RoleRepository : Repository<Role>, IRoleRepository
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
        public async Task<IRole> FindByIdAsync(Guid id)
        {
            var entity = await GetAsync(x => x.RoleId == id);
            return Mapper.Map<IRole>(entity);
        }

        /// <summary>
        /// Finds the by name asynchronous.
        /// </summary>
        /// <param name="roleName">Name of the role.</param>
        /// <returns></returns>
        public async Task<IRole> FindByNameAsync(string roleName)
        {
            var entity = await GetAsync(x => x.Name == roleName);
            return Mapper.Map<IRole>(entity);
        }

        /// <summary>
        /// Adds the <see cref="IRole"/> asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task.</returns>
        public Task AddAsync(IRole model)
        {
            var entity = Mapper.Map<Role>(model);
            return Task.FromResult(DbSet.Add(entity));
        }

        /// <summary>
        /// Asynchronously deletes <see cref="IUser"/> form the database.
        /// </summary>
        /// <param name="model">Model.</param>
        public Task DeleteAsync(IRole model)
        {
            var entity = Mapper.Map<Role>(model);
            DbSet.Remove(entity);
            return Task.FromResult(true);
        }

        /// <summary>
        /// Asynchronously updates entity in the database.
        /// </summary>
        /// <param name="entity">Entity.</param>
        public Task UpdateAsync(IRole model)
        {
            var entity = Mapper.Map<Role>(model);
            DbSet.Attach(entity);
            ((IObjectContextAdapter)Context).ObjectContext.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
            return Task.FromResult(true);
        }

        /// <summary>
        /// Gets all records.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Enumerable list of records.</returns>
        public IList<IRole> GetAll()
        {
            var entities = DbSet.ToList();
            return Mapper.Map<IList<IRole>>(entities);
        }
    }
}
