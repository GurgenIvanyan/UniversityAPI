using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web.Core.Models;

namespace Infrastructure.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<CourseEntity>
    {
        public void Configure(EntityTypeBuilder<CourseEntity> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.Author)
                   .WithOne(a => a.Course)
                   .HasForeignKey<AuthorEntity>(a => a.CourseId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Lessons)
                   .WithOne(l => l.Course)
                   .HasForeignKey(l => l.CourseId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Students)
                   .WithMany(s => s.Courses);
        }
    }
}
