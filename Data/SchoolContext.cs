///////////////////////////////////////////////////////
// TINFO 200 A, Winter 2021
// UWTacoma SET, Daniel Androussenko
// 03-13-2021
// L7mvc - Contoso University
// This is an ASP.NET Core web application project for performing database-related operations for a University.
// This includes standard CRUD operations for students, courses, instructors, and departments. So far, only  CRUD operations for students are working.
// Please note, the change history is implemented as tags within the code and the architecture and code is described and annotated within the code itself.
///////////////////////////////////////////////////////
// Sources --------------
// Microsoft Docs - Tutorial: Get started with EF Core in an ASP.NET MVC web app
// Link: https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-5.0

using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Data
{
    // According to the Microsoft Docs, the DBContext class represents a session with the database
    // allowing for queries and saving entity instances to the database.
    // In this case, the SchoolContext inherits from DbContext and holds DbSet properties, explained below.
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {

        }

        // tinfo200:[2021-03-03-dandrous-dykstra1] -- Imported code from "Get started" tutorial to create the SchoolContext class
        // and provide DbSet properties for each entity in the Model folder
        // Each DbSet property represents the collection of all entities specified by the type (i.e. Student, Enrollment, and Course)
        // Each DbSet corresponds to a single database table that holds each entity of the DbSet<T>'s type and their corresponding data as data rows
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }


        // tinfo200:[2021-03-03-dandrous-dykstra1] -- Imported code from "Get started" tutorial to
        // This code prevents naming discrepancies by specifying the use of a singular naming convention for database tables
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");
        }
    }
}