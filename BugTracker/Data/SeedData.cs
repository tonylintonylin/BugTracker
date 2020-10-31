using BugTracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

// dotnet aspnet-codegenerator razorpage -m Contact -dc ApplicationDbContext -udl -outDir Pages\Contacts --referenceScriptLibraries

namespace BugTracker.Data
{
    public static class SeedData
    {
        public static void SeedDB(ApplicationDbContext context)
        {
            if (context.Projects.Any())
            {
                return;   // DB has been seeded
            }
            
            /*
            var Projects = new Project[]
            {
                new Project{Name="Bug Tracker",
                    Description="The first bug tracker project",
                    Creator="Me"},

                new Project{Name="Seeded",
                    Description="This is the second seeded project",
                    Creator="SeedData.cs"},

                new Project{Name="Project Name",
                    Description="This is the project description",
                    Creator="Who created this?"}
            };

            context.Projects.AddRange(Projects);
            context.SaveChanges();

            var Tickets = new Ticket[]
            {
                new Ticket{ID=1050,
                    Title="Assign tickets to developers",
                    Description="Tickets and developers have a many to many relationship",
                    Status=Status.InProgress,
                    Creator="Seeded value",
                    ProjectID = Projects.Single( s => s.Name == "Bug Tracker").ProjectID},

                new Ticket{ID=4022,
                    Title="Filter tickets to assigned developers",
                    Description="Make it easy for developers to see tickets assigned to them",
                    Status=Status.New,
                    Creator="Seeded value",
                    ProjectID = Projects.Single( s => s.Name == "Bug Tracker").ProjectID},

                new Ticket{ID=4041,
                    Title="3rd ticket",
                    Description="This is the third ticket in the Bug Tracker project",
                    Status=Status.Completed,
                    Creator="Seeded value",
                    ProjectID = Projects.Single( s => s.Name == "Bug Tracker").ProjectID},

                new Ticket{ID=1045,
                    Title="Check Project and Ticket relationship",
                    Description="Make sure Projects and Tickets have a 1 to many relationship (1-*). Every Project may have many Tickets. Every Ticket may only be associated with 1 Project.",
                    Status=Status.InProgress,
                    Creator="Seeded value",
                    ProjectID = Projects.Single( s => s.Name == "Bug Tracker").ProjectID},

                new Ticket{ID=3141,
                    Title="1st seeded ticket",
                    Description="1st seeded ticket for the 2nd project named Seeded",
                    Status=Status.New,
                    Creator="Seeded value",
                    ProjectID = Projects.Single( s => s.Name == "Seeded").ProjectID},

                new Ticket{ID=2021,
                    Title="2nd seeded ticket",
                    Description="2nd seeded ticket for the 2nd project named Seeded",
                    Status=Status.New,
                    Creator="Seeded value",
                    ProjectID = Projects.Single( s => s.Name == "Seeded").ProjectID},

                new Ticket{ID=2042,
                    Title="1st ticket title",
                    Description="This is the description for the 1st ticket in the 3rd project named Project Name",
                    Status=Status.Completed,
                    Creator="Seeded value",
                    ProjectID = Projects.Single( s => s.Name == "Project Name").ProjectID}
            };

            context.Tickets.AddRange(Tickets);
            context.SaveChanges();
            */
        }
    }
}