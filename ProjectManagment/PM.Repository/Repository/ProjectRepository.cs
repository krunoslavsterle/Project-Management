using System.Threading.Tasks;
using PM.DAL;
using PM.Model.Common;
using PM.Common;
using PM.Repository.Common;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using PM.Common.Filters;

namespace PM.Repository
{
    /// <summary>
    /// Project repository.
    /// </summary>
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        #region Constructors
        
        public ProjectRepository(PMDatabaseEntities Context, IMapper mapper) 
            : base(Context, mapper)
        {
            
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets the <see cref="IProjectPoco"/> asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<IProjectPoco> GetProjectAsync(Guid id)
        {
            var entity = await GetAsync(p => p.Id == id);
            return Mapper.Map<IProjectPoco>(entity);
        }

        /// <summary>
        /// Adds the project asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public System.Threading.Tasks.Task AddAsync(IProjectPoco model)
        {
            var entity = Mapper.Map<Project>(model);
            return System.Threading.Tasks.Task.FromResult(DbSet.Add(entity));
        }

        /// <summary>
        /// Finds the list of <see cref="IProjectPoco"/>'s asynchronous.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The list of <see cref="IProject"/>'s.</returns>
        public async Task<IList<IProjectPoco>> FindAsync(ProjectFilter filter)
        {
            var query = DbSet.AsQueryable();

            if (filter != null)
            {
                if (!String.IsNullOrEmpty(filter.Name))
                    query = query.Where(p => p.Name.Contains(filter.Name));

                if (!String.IsNullOrEmpty(filter.Description))
                    query = query.Where(p => p.Description.Contains(filter.Description));

                if (filter.OwnerId.HasValue)
                    query = query.Where(p => p.OwnerId == filter.OwnerId.Value);
            }

            var domainList = await query.ToListAsync();
            return Mapper.Map<IList<IProjectPoco>>(domainList);
        }

        #endregion Methods
    }
}
