using System;
using System.Threading;
using System.Threading.Tasks;

namespace PM.Repository.Common
{
    /// <summary>
    /// Unit of work contract.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IUnitOfWork : IDisposable
    {
        #region Properties

        /// <summary>
        /// Gets the external login repository.
        /// </summary>
        /// <value>
        /// The external login repository.
        /// </value>
        IExternalLoginRepository ExternalLoginRepository { get; }

        /// <summary>
        /// Gets the role repository.
        /// </summary>
        /// <value>
        /// The role repository.
        /// </value>
        IRoleRepository RoleRepository { get; }

        /// <summary>
        /// Gets the user repository.
        /// </summary>
        /// <value>
        /// The user repository.
        /// </value>
        IUserRepository UserRepository { get; }

        /// <summary>
        /// Gets the project repository.
        /// </summary>
        /// <value>
        /// The project repository.
        /// </value>
        IProjectRepository ProjectRepository { get; }

        /// <summary>
        /// Gets the task repository.
        /// </summary>
        /// <value>
        /// The task repository.
        /// </value>
        ITaskRepository TaskRepository { get; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        /// <summary>
        /// Saves the changes asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// Saves the changes asynchronous.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        #endregion Methods
    }
}
