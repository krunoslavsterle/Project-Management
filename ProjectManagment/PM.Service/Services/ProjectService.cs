using PM.Model.Common;
using PM.Repository.Common;
using PM.Service.Common;
using System;
using System.Threading.Tasks;

namespace PM.Service
{
    /// <summary>
    /// Project service.
    /// </summary>
    public class ProjectService : BaseService, IProjectService
    {
        #region Constructors

        public ProjectService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Adds the project asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns><see cref="IProject"/>. </returns>
        public async Task<bool> AddAsync(IProject model)
        {
            model.Id = Guid.NewGuid();
            model.DateCreated = DateTime.UtcNow;
            model.DateUpdated = DateTime.UtcNow;

            await UnitOfWork.ProjectRepository.AddAsync(model);
            return await UnitOfWork.SaveChangesAsync() > 0;
        }

        #endregion Methods
    }
}
