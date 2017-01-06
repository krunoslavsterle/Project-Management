using PM.Common;
using PM.Common.Filters;
using PM.DAL;
using PM.Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
using PM.Repository.Common;

namespace PM.Repository
{
    /// <summary>
    /// Task repository class.
    /// </summary>
    /// <seealso cref="PM.Repository.Repository{PM.DAL.Task}" />
    public class TaskRepository : Repository<DAL.Task>, ITaskRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="mapper">The mapper.</param>
        public TaskRepository(PMDatabaseEntities context, IMapper mapper)
            : base(context, mapper)
        {

        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets the task asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<ITaskPoco> GetTaskAsync(Guid id)
        {
            var entity = await GetAsync(p => p.Id == id);
            return Mapper.Map<ITaskPoco>(entity);
        }

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task.</returns>
        public System.Threading.Tasks.Task AddAsync(ITaskPoco model)
        {
            var entity = Mapper.Map<DAL.Task>(model);
            return System.Threading.Tasks.Task.FromResult(DbSet.Add(entity));
        }


        /// <summary>
        /// Finds the list of tasks asynchronous.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>List of <see cref="ITaskPoco"/>.</returns>
        public async Task<IList<ITaskPoco>> FindAsync(TaskFilter filter)
        {
            var query = DbSet.AsQueryable();

            if (filter != null)
            {
                //    if (!String.IsNullOrEmpty(filter.Name))
                //        query = query.Where(p => p.Name.Contains(filter.Name));
            }

            var domainList = await query.ToListAsync();
            return Mapper.Map<IList<ITaskPoco>>(domainList);
        }


        #endregion Methods
    }
}
