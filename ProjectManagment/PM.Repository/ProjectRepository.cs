using PM.DAL.Entities;
using System.Threading.Tasks;
using PM.DAL;
using PM.Model.Common;
using PM.Common;
using PM.Repository.Common;

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
        /// Adds the project asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public Task AddAsync(IProject model)
        {
            var entity = Mapper.Map<ProjectEntity>(model);
            return Task.FromResult(DbSet.Add(entity));
        }

        #endregion Methods
    }
}
