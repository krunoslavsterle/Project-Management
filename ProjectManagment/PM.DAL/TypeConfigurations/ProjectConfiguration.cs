using System.Data.Entity.ModelConfiguration;

namespace PM.DAL.TypeConfigurations
{
    /// <summary>
    /// Project entity configuration.
    /// </summary>
    public class ProjectConfiguration : EntityTypeConfiguration<Project>
    {
        #region Constructors

        /// <summary>
        /// Initialize a new instance of <see cref="ProjectConfiguration"/> class.
        /// </summary>
        public ProjectConfiguration()
        {
            // Primary key.
            this.HasKey(p => p.Id);

            this.ToTable("Project");
            this.Property(p => p.OwnerId).HasColumnName("OwnerId");
            this.Property(p => p.Name).HasColumnName("Name").HasMaxLength(50);
            this.Property(p => p.Description).HasColumnName("Description");
            this.Property(p => p.DateCreated).HasColumnName("DateCreated");
            this.Property(p => p.DateUpdated).HasColumnName("DateUpdated");
        }

        #endregion Constructors
    }
}
