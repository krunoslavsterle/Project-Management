using PM.DAL.Entities;
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
    public class ProjectRepository : Repository<ProjectEntity>, IProjectRepository
    {
        #region Constructors
        
        public ProjectRepository(PMAppContext Context, IMapper mapper) 
            : base(Context, mapper)
        {
            
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets the <see cref="IProject"/> asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<IProject> GetProjectAsync(Guid id)
        {
            var entity = await GetAsync(p => p.Id == id);
            return Mapper.Map<IProject>(entity);
        }

        /// <summary>
        /// Adds the project asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public Task AddAsync(IProject model)
        {
            var entity = Mapper.Map<ProjectEntity>(model);
            return Task.FromResult(DbSet.Add(entity));
        }

        /// <summary>
        /// Finds the list of <see cref="IProject"/>'s asynchronous.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public async Task<IList<IProject>> FindAsync(ProjectFilter filter)
        {
            var query = DbSet.AsQueryable();

            if (filter != null)
            {
                if (!String.IsNullOrEmpty(filter.Name))
                {
                    query.Where(p => p.Name.Contains(filter.Name));
                }

                if (!String.IsNullOrEmpty(filter.Description))
                {
                    query.Where(p => p.Description.Contains(filter.Description));
                }
            }

            var domainList = await query.ToListAsync();
            return Mapper.Map<IList<IProject>>(domainList);
        }

        #endregion Methods
    }
}
