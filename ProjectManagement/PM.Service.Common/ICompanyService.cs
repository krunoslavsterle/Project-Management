using PM.Model.Common;
using System;
using System.Threading.Tasks;

namespace PM.Service.Common
{
    /// <summary>
    /// Company Service contract.
    /// </summary>
    public interface ICompanyService
    {
        /// <summary>
        /// Creates a new <see cref="ICompanyPoco"/> in memory instance.
        /// </summary>
        /// <returns>A new <see cref="ICompanyPoco"/> in memory instance.</returns>
        ICompanyPoco Create();

        /// <summary>
        /// Inserts the specified <see cref="ICompanyPoco"/> model into the database asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        Task InsertAsync(ICompanyPoco model);

        /// <summary>
        /// Deletes model by id asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        Task DeleteAsync(Guid id);
    }
}
