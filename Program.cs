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

using ContosoUniversity.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity
{
    public class Program
    {
        // tinfo200:[2021-03-03-dandrous-dykstra1] -- Imported code from "Get started" tutorial
        // The imported code creates a database context, initializes it with data, and disposes the context. More detailed explanation below.
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            CreateDbIfNotExists(host);

            host.Run();
        }

        
        // Method to create the database if it does not already exist using DbInitializer
        private static void CreateDbIfNotExists(IHost host)
        {
            // Dispose of any services at the end of this using block
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                // Initialize the database context using the DbInitializer.Initialize() method
                try
                {
                    // Using dependency injection, retrieve the database context
                    var context = services.GetRequiredService<SchoolContext>();
                    // Initialize the context
                    // Note, the DbContext instance does not directly represent the database, but is referred to in that manner here
                    // Instead, the SchoolContext represents the link between the database and the data models, 
                    // as well as the actual session with the database providing connections between the database and EF core.
                    DbInitializer.Initialize(context);
                }
                // Catch and log any errors when initializing the database context
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
