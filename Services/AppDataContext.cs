using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using assign2.Services.Entities;

namespace assign2.Services
{
    public class AppDataContext : DbContext
    {
        public DbSet<Course>         Courses          {get; set;}
        public DbSet<CourseTemplate> CoursesTemplates {get; set;}
        public DbSet<CourseStudent> CourseStudents   {get; set;}
        public DbSet<Student>        Students         {get; set;}

        public AppDataContext(DbContextOptions<AppDataContext> options)
            : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
