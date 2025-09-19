using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web.Core.Models;

namespace Infrastructure.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<AuthorEntity>
    {
        public void Configure(EntityTypeBuilder<AuthorEntity> builder)
        {
            
            builder.HasKey(a => a.Id);

       
            builder.HasOne(a => a.Course)
                   .WithOne(c => c.Author) 
                   .HasForeignKey<AuthorEntity>(a => a.CourseId)
                   .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
