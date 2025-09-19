using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Web.Core.Models;
using Infrastructure.Configurations;

namespace Infrastructure
{
    public class WebDbContext : DbContext
    {
        
        public WebDbContext() { }

      
        public WebDbContext(DbContextOptions<WebDbContext> options)
            : base(options)
        {
        }

        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<LessonEntity> Lessons { get; set; }
        public DbSet<AuthorEntity> Authors { get; set; }
        public DbSet<StudentEntity> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new LessonConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());


            modelBuilder.Entity<StudentEntity>()
          .HasMany(s => s.Courses)
          .WithMany(c => c.Students)
          .UsingEntity<Dictionary<string, object>>(
              "StudentCourse",
              j => j.HasOne<CourseEntity>().WithMany().HasForeignKey("CourseId"),
              j => j.HasOne<StudentEntity>().WithMany().HasForeignKey("StudentId")
          );

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
                optionsBuilder.UseNpgsql(
                    "Host=localhost;Database=WebDbContext; Username=postgres;Password=Gurgen2003%"
                );
            }
        }
    }
}
