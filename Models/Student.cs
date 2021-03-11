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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Models
{
    public class Student
    {
        // tinfo200:[2021-03-03-dandrous-dykstra1] -- Developed POCO class model for Student entity
        // The ID property represents the primary key - The thing used to ensure data uniqueness of an entity in the database

        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        // One to many relationship, thus a collection is used
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
