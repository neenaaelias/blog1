namespace blog1.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Runtime.Remoting.Contexts;
    using System.Xml.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<blog1.Models.ApplicationDbContext>
    {

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            ////create the Admin role
            //var roleManager = new RoleManager<IdentityRole>(
            //    new RoleStore<IdentityRole>(context));
            //if (!context.Roles.Any(r => r.Name == "Admin"))

            //{
            //    roleManager.Create(new IdentityRole { Name = "Admin" });
            //}

            ////CREATE THE USER
            //var userManager = new UserManager<ApplicationUser>(
            //    new UserStore<ApplicationUser>(context));
            //if (!context.Users.Any(u => u.Email == "neenaaelias@gmail.com"))
            //{
            //    userManager.Create(new ApplicationUser
            //    {
            //        UserName = "neenaaelias@gmail.com",
            //        Email = "neenaaelias@gmail.com",
            //        FirstName = "neena",
            //        LastName = "aelias",
            //        DisplayName = "neenatom"
            //    }, "password");
            //}

            //// associate the user to role
            //var userId = userManager.FindByEmail("neenaaelias@gmail.com").Id;
            //userManager.AddToRole(userId, "Admin");


            //create the moderator role
            //var moderator = new RoleManager<IdentityRole>(
            //    new RoleStore<IdentityRole>(context));
            //if (!context.Roles.Any(r => r.Name == "Moderator"))

            //{
            //    moderator.Create(new IdentityRole { Name = "Moderator" });
            //}

            //CREATE THE USER
            var userModerator = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            if (!context.Users.Any(u => u.Email == "thomsonin@gmail.com"))
            {
                userModerator.Create(new ApplicationUser
                {
                    UserName ="thomsonin@gmail.com",
                    Email = "thomsonin@gmail.com",
                    FirstName = "thomson",
                    LastName = "thomas",
                    DisplayName = "tom"
                }, "password");


            }

            // associate the user to role
            var moderatorId = userModerator.FindByEmail("thomsonin@gmail.com").Id;
            userModerator.AddToRole(moderatorId, "Moderator");


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //




        }
    }
}