namespace PM.Common
{
    /// <summary>
    /// Sorting pair class.
    /// </summary>
    /// <seealso cref="PM.Common.ISortingPair" />
    public class SortingPair : ISortingPair
    {
        #region Properties

        /// <summary>
        /// Gets a value indicating if order direction is ascending.
        /// </summary>
        public bool IsAscending { get; set; }

        /// <summary>
        /// Gets the order by field.
        /// </summary>
        public string OrderBy { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SortingPair"/> class.
        /// </summary>
        /// <param name="orderBy">Order by field.</param>
        /// <param name="ascending">Order direction.</param>
        public SortingPair(string orderBy, bool isAscending)
        {
            OrderBy = orderBy;
            IsAscending = isAscending;
        }

        #endregion Constructors
        
    }
}
