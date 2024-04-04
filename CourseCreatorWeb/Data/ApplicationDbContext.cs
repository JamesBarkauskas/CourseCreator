using CourseCreatorWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseCreatorWeb.Data
{
    // this is what sets up a session with the database, allowing us to make changes to the db using an instance of this class
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Create the Courses Table for the db
        public DbSet<Course> Courses { get; set; }

        // adding a few default courses
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Title = "Intro to Computer Science", Subject = "Computer Science", Description = "An introduction to the fundamentals of computer science.", CreditHours = 3 },
                new Course { Id = 2, Title = "Calculus 1", Subject = "Math", Description = "Introduction to calculus.", CreditHours = 3 },
                new Course { Id = 3, Title = "Software Systems Capstone", Subject = "Computer Science", Description = "Building a sophisticated, real-world application.", CreditHours = 3 }
                );
        }
    }
}
