using PM.Model.Common;
using PM.Repository;
using PM.Service.Common;
using System;

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

        #endregion Methods
    }
}
