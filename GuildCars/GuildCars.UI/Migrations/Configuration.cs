namespace GuildCars.UI.Migrations
{
    using GuildCars.UI.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GuildCars.UI.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GuildCars.UI.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            string[] roles = new string[] { "Admin", "Sales","Disabled" };
            foreach (string role in roles)
            {
                if (!context.Roles.Any(r => r.Name == role))
                {
                    context.Roles.Add(new IdentityRole(role));
                }

            }

            //create user UserName:sys_admin@GuildCars.com Role:Admin
            if (!context.Users.Any(u => u.UserName == "sys_admin@GuildCars.com"))
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var user = new ApplicationUser
                {
                    FirstName = "Admin",
                    LastName = "Default",
                    Email = "sys_admin@GuildCars.com",
                    UserName = "sys_admin@GuildCars.com",
                    PhoneNumber = "+111111111111",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    PasswordHash = userManager.PasswordHasher.HashPassword("secret"),
                    LockoutEnabled = false,
                    TwoFactorEnabled = false,
                    AccessFailedCount = 0,

                };
                userManager.Create(user);
                userManager.AddToRole(user.Id, "Admin");
            }

            context.SaveChanges();
        }
    }
}
