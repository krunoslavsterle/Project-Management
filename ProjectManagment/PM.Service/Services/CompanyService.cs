using PM.Model.Common;
using PM.Repository;
using PM.Service.Common;
using System;
using System.Threading.Tasks;

namespace PM.Service
{
    /// <summary>
    /// Company Service.
    /// </summary>
    public class CompanyService : ICompanyService
    {
        #region Fields

        private readonly ICompanyRepository companyRepository;

        #endregion Fields

        #region Constructors

        public CompanyService(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Creates a new <see cref="ICompanyPoco"/> in memory instance.
        /// </summary>
        /// <returns>A new <see cref="ICompanyPoco"/> in memory instance.</returns>
        public virtual ICompanyPoco Create()
        {
            return companyRepository.Create();
        }

        /// <summary>
        /// Inserts the specified <see cref="ICompanyPoco"/> model into the database asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual Task InsertAsync(ICompanyPoco model)
        {
            return companyRepository.InsertAsync(model);
        }

        /// <summary>
        /// Deletes model by id asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public virtual Task DeleteAsync(Guid id)
        {
            return companyRepository.DeleteAsync(id);
        }

        #endregion Methods
    }
}
