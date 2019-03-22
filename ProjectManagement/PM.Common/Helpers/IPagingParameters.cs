namespace PM.Common
{
    /// <summary>
    /// Paging parameters contract.
    /// </summary>
    public interface IPagingParameters
    {
        /// <summary>
        /// Gets the page number.
        /// </summary>
        /// <value>
        /// The page number.
        /// </value>
        int PageNumber { get; }

        /// <summary>
        /// Gets the size of the page.
        /// </summary>
        /// <value>
        /// The size of the page.
        /// </value>
        int PageSize { get; }

        /// <summary>
        /// Gets the ammount to skip.
        /// </summary>
        /// <value>
        /// The skip.
        /// </value>
        int Skip { get; }
    }
}
