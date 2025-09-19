using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web.Core.Models;

namespace Infrastructure.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<StudentEntity>
    {
        public void Configure(EntityTypeBuilder<StudentEntity> builder)
        {
            
            builder.HasKey(s => s.Id);

            builder.HasMany(s => s.Courses)
                   .WithMany(c => c.Students)
                   .UsingEntity<Dictionary<string, object>>( 
                       "StudentCourse", 
                       j => j.HasOne<CourseEntity>()
                             .WithMany()
                             .HasForeignKey("CourseId")
                             .OnDelete(DeleteBehavior.Cascade),
                       j => j.HasOne<StudentEntity>()
                             .WithMany()
                             .HasForeignKey("StudentId")
                             .OnDelete(DeleteBehavior.Cascade),
                       j =>
                       {
                           j.HasKey("StudentId", "CourseId"); 
                       });

           
            builder.Property(s => s.UserName)
                   .IsRequired()
                   .HasMaxLength(100);
        }
    }
}
