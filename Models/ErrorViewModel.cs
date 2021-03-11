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

namespace ContosoUniversity.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
