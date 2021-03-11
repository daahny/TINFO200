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

namespace ContosoUniversity.Models
{
    // tinfo200:[2021-03-03-dandrous-dykstra1] -- Developed POCO class model for Enrollment entity
    // Primary key (explained in the Student model) is Enrollment ID
    // The foreign key is the key used to connect data columns between 2 data tables. It refers to another entity's primary key. In this case, CourseID and StudentID are the foreign key for Enrollment
    // Represents student's grade
    public enum Grade
    {
        A, B, C, D, F
    }
    public class Enrollment
    {
        // Primary key
        public int EnrollmentID { get; set; }
        // Foreign key
        public int CourseID { get; set; }
        // Foreign key
        public int StudentID { get; set; }
        // Nullable type property
        public Grade? Grade { get; set; }

        // Many to one relationship
        // Navigation properties to carry or navigate associations with Course and Student entities
        public Course Course { get; set; }
        public Student Student { get; set; }

    }
}