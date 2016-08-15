using PM.Repository.Common;

namespace PM.Service
{
    /// <summary>
    /// Base service abstract class.
    /// </summary>
    public abstract class BaseService
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public BaseService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the unit of work.
        /// </summary>
        /// <value>
        /// The unit of work.
        /// </value>
        public IUnitOfWork UnitOfWork { get; private set; }

        #endregion Properties
    }
}
