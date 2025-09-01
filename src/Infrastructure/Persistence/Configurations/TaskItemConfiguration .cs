using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class TaskItemConfiguration : IEntityTypeConfiguration<TaskItem>
    {
        public void Configure(EntityTypeBuilder<TaskItem> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Title).IsRequired().HasMaxLength(200);

            // Map TaskState enum (as string for readability)
            builder.Property(t => t.Status)
                   .HasConversion(
                       v => v.ToString(),
                       v => (TaskState)Enum.Parse(typeof(TaskState), v))
                   .IsRequired();

            // Map Value Object DueDate
            builder.OwnsOne(t => t.DueDate, dd =>
            {
                dd.Property(d => d.ValueUtc)
                  .HasColumnName("DueDate")
                  .IsRequired();
            });
        }
    }
}
