
using PM.Common;
using PM.DAL;
using PM.Repository.Common;
using PM.Repository.Identity;
using System.Threading.Tasks;

namespace PM.Repository
{
    /// <summary>
    /// Unit of work.
    /// </summary>
    /// <seealso cref="PM.Repository.Common.IUnitOfWork" />
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields

        private readonly PMDatabaseEntities _context;
        private IMapper _mapper;

        private IExternalLoginRepository _externalLoginRepository;
        private IRoleRepository _roleRepository;
        private IUserRepository _userRepository;
        private IProjectRepository projectRepository;

        #endregion Fields

        #region Constructors
        
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        public UnitOfWork(IMapper mapper)
        {
            _context = new PMDatabaseEntities();
            _mapper = mapper;
        }

        #endregion Constructors

        #region IUnitOfWork Members

        /// <summary>
        /// Gets the external login repository.
        /// </summary>
        /// <value>
        /// The external login repository.
        /// </value>
        public IExternalLoginRepository ExternalLoginRepository
        {
            get { return _externalLoginRepository ?? (_externalLoginRepository = new ExternalLoginRepository(_context, _mapper)); }
        }

        /// <summary>
        /// Gets the role repository.
        /// </summary>
        /// <value>
        /// The role repository.
        /// </value>
        public IRoleRepository RoleRepository
        {
            get { return _roleRepository ?? (_roleRepository = new RoleRepository(_context, _mapper)); }
        }

        /// <summary>
        /// Gets the user repository.
        /// </summary>
        /// <value>
        /// The user repository.
        /// </value>
        public IUserRepository UserRepository
        {
            get { return _userRepository ?? (_userRepository = new UserRepository(_context, _mapper)); }
        }

        /// <summary>
        /// Gets the project repository.
        /// </summary>
        /// <value>
        /// The project repository.
        /// </value>
        public IProjectRepository ProjectRepository
        {
            get { return projectRepository ?? (projectRepository = new ProjectRepository(_context, _mapper)); }
        }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        /// <summary>
        /// Saves the changes asynchronous.
        /// </summary>
        /// <returns></returns>
        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        /// <summary>
        /// Saves the changes asynchronous.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        #endregion IUnitOfWork Members

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _externalLoginRepository = null;
            _roleRepository = null;
            _userRepository = null;
            _context.Dispose();
        }

        #endregion IDisposable Members
    }

}
