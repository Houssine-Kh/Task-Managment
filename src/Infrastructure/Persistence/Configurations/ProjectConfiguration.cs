using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(200);

            // One-to-many: Project -> Tasks
            builder.HasMany(p => p.Tasks)
                   .WithOne()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
