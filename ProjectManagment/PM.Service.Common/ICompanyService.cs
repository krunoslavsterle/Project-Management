using PM.Model.Common;

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
    }
}
