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
            Database.SetInitializer<PMAppContext>(new PMDbInitializer());
        }

        #endregion Constructors

        #region Methods

        public virtual IDbSet<UserEntity> Users { get; set; }
        public virtual IDbSet<RoleEntity> Roles { get; set; }
        public virtual IDbSet<ExternalLoginEntity> Logins { get; set; }
        public virtual IDbSet<ProjectEntity> Projects { get; set; }

        /// <summary>
        /// On model creating method.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClaimConfiguration());
            modelBuilder.Configurations.Add(new ExternalLoginConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new ProjectConfiguration());
            
        }

        #endregion Methods
    }
}
