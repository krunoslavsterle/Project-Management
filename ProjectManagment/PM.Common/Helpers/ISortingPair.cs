namespace PM.Common
{
    /// <summary>
    /// Sorting pair contract.
    /// </summary>
    public interface ISortingPair
    {
        #region Properties

        /// <summary>
        /// Gets a value indicating if order direction is ascending.
        /// </summary>
        bool IsAscending { get; set; }

        /// <summary>
        /// Gets the order by field.
        /// </summary>
        string OrderBy { get; set; }

        #endregion Properties
    }
}
