using System.Collections.Generic;

namespace PM.Common
{
    /// <summary>
    /// Sorting parameters contract.
    /// </summary>
    public interface ISortingParameters
    {
        #region Properties

        /// <summary>
        /// Gets the sort pairs.
        /// </summary>
        IList<ISortingPair> Sorters { get; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Adds a new sorting pair.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="isAscending">if set to <c>true</c> [is ascending].</param>
        void Add(string orderBy, bool isAscending);

        /// <summary>
        /// Adds a new sorting pair.
        /// </summary>
        /// <param name="sortingPair">The sorting pair.</param>
        void Add(ISortingPair sortingPair);

        #endregion Methods
    }
}
