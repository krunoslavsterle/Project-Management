using PM.DAL.Entities;
using PM.DAL.TypeConfigurations;
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
        
        public virtual DbSet<ProjectEntity> Projects { get; set; }

        /// <summary>
        /// On model creating method.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProjectConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        #endregion Methods
    }
}
