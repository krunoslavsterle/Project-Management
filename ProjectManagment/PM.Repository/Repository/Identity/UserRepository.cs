using PM.DAL;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using PM.Model.Common;
using PM.Common;
using System;

namespace PM.Repository
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="mapper">The mapper.</param>
        internal UserRepository(PMDatabaseEntities context, IMapper mapper)
            : base(context, mapper)
        {
        }

        /// <summary>
        /// Finds <see cref="IUser"/> the by user name asynchronous.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns><see cref="IUser"/>.</returns>
        public async Task<IUser> FindByUserNameAsync(string username)
        {
            var entity = await GetAsync(x => x.UserName == username);
            return Mapper.Map<IUser>(entity);
        }

        /// <summary>
        /// Gets <see cref="IUser"/> the by user identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="IUser"/>.</returns>
        public async Task<IUser> GetByUserIdAsync(Guid id)
        {
            var entity = await GetAsync(i => i.UserId == id);
            return Mapper.Map<IUser>(entity);
        }

        /// <summary>
        /// Adds the <see cref="IUser"/> asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task.</returns>
        public Task AddAsync(IUser model)
        {
            model.DateCreated = DateTime.UtcNow;
            model.DateUpdated = DateTime.UtcNow;
            var entity = Mapper.Map<User>(model);
            return Task.FromResult(DbSet.Add(entity));
        }
        
        /// <summary>
        /// Asynchronously deletes <see cref="IUser"/> form the database.
        /// </summary>
        /// <param name="model">Model.</param>
        public Task DeleteAsync(IUser model)
        {
            var entity = Mapper.Map<User>(model);
            DbSet.Remove(entity);
            return Task.FromResult(true);
        }

        /// <summary>
        /// Asynchronously updates entity in the database.
        /// </summary>
        /// <param name="entity">Entity.</param>
        public Task UpdateAsync(IUser model)
        {
            model.DateUpdated = DateTime.UtcNow;
            var entity = Mapper.Map<User>(model);
            DbSet.Attach(entity);
            ((IObjectContextAdapter)Context).ObjectContext.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
            return Task.FromResult(true);
        }

        /// <summary>
        /// Creates the claim asynchronous.
        /// </summary>
        /// <returns><see cref="IClaim"/>.</returns>
        public Task<IClaim> CreateClaimAsync()
        {
            IClaim claim = new Model.ClaimPoco();
            return Task.FromResult(claim);
        }
    }
}