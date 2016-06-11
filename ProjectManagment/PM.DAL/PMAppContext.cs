using System.Data.Entity;

namespace PM.DAL
{
    /// <summary>
    /// PM app context class.
    /// </summary>
    public class PMAppContext : DbContext
    {
        #region Constructors

        /// <summary>
        /// Initialize a new instance of <see cref="PMAppContext"/> class.
        /// </summary>
        public PMAppContext() : base("PMLocalDBConnection")
        {

        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// On model creating method.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        #endregion Methods
    }
}
