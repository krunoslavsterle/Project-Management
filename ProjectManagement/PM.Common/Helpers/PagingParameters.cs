using System;

namespace PM.Common
{
    /// <summary>
    /// Paging parameters class.
    /// </summary>
    /// <seealso cref="PM.Common.IPagingParameters" />
    public class PagingParameters : IPagingParameters
    {
        #region Properties

        /// <summary>
        /// Gets the page number.
        /// </summary>
        /// <value>
        /// The page number.
        /// </value>
        public int PageNumber { get; private set; }

        /// <summary>
        /// Gets the size of the page.
        /// </summary>
        /// <value>
        /// The size of the page.
        /// </value>
        public int PageSize { get; private set; }

        /// <summary>
        /// Gets the ammount to skip.
        /// </summary>
        /// <value>
        /// The skip.
        /// </value>
        public int Skip
        {
            get
            {
                return (PageNumber - 1) * PageSize;
            }
        }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PagingParameters"/> class.
        /// </summary>
        public PagingParameters()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagingParameters"/> class.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <exception cref="System.Exception">
        /// The page number must be greater than 0
        /// or
        /// The page size must be greater than 0
        /// </exception>
        public PagingParameters(int pageNumber, int pageSize)
        {
            if (pageNumber < 1)
                throw new Exception("The page number must be greater than 0");

            if (pageSize < 1)
                throw new Exception("The page size must be greater than 0");

            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
        }

        #endregion Constructors
    }
}
