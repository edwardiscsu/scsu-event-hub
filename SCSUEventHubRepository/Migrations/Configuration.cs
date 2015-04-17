namespace SCSUEventHubRepository.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SCSUEventHubModels.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SCSUEventHubRepository.Entity.EventHubDBEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SCSUEventHubRepository.Entity.EventHubDBEntities context)
        {
            UserManager<Account> userManager = new UserManager<Account>(new UserStore<Account>(context));
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            string roleT1 = "T1 Administrator";
            if (!roleManager.RoleExists(roleT1))
            {
                IdentityResult roleResult = roleManager.Create(new IdentityRole(roleT1));
                if (roleResult.Succeeded)
                {
                    Admin adminUser = new Admin() { UserName = "Harlan" };
                    IdentityResult userResult = userManager.Create(adminUser, "SCSU@2015");
                    if (userResult.Succeeded)
                    {
                        IdentityResult result = userManager.AddToRole(adminUser.Id, roleT1);
                    }
                }

                if (roleResult.Succeeded)
                {
                    Admin adminUser = new Admin() { UserName = "Edward" };
                    IdentityResult userResult = userManager.Create(adminUser, "SCSU@2015");
                    if (userResult.Succeeded)
                    {
                        IdentityResult result = userManager.AddToRole(adminUser.Id, roleT1);
                    }
                }

                if (roleResult.Succeeded)
                {
                    Admin adminUser = new Admin() { UserName = "Pramuka" };
                    IdentityResult userResult = userManager.Create(adminUser, "SCSU@2015");
                    if (userResult.Succeeded)
                    {
                        IdentityResult result = userManager.AddToRole(adminUser.Id, roleT1);
                    }
                }
            }

            string roleT2 = "T2 Administrator";
            if (!roleManager.RoleExists(roleT2))
            {
                IdentityResult roleResult = roleManager.Create(new IdentityRole(roleT2));
            }

            string roleT3 = "T3 Administrator";
            if (!roleManager.RoleExists(roleT3))
            {
                IdentityResult roleResult = roleManager.Create(new IdentityRole(roleT3));
            }

            Category[] categories = new Category[] {
                new Category { CategoryName = "Athletics" },
                new Category { CategoryName = "Conferences & Workshops" },
                new Category { CategoryName = "Cultural" },
                new Category { CategoryName = "Entertainment" },
                new Category { CategoryName = "Fine Arts" },
                new Category { CategoryName = "Recreation" },
                new Category { CategoryName = "Speakers" },
                new Category { CategoryName = "Special Events" },
            };

            context.Categories.AddOrUpdate(
                record => record.CategoryName,
                categories
            );

            Event[] events = new Event[] {

            };

            context.Events.AddOrUpdate(
                record => record.EventName,
                events
            );

            Recommendation[] recommendations = new Recommendation[] {

            };

            context.Recommendations.AddOrUpdate(
                record => new { record.EventID, record.UserID },
                recommendations
            );

            CategorySubscription[] categorySubscriptions = new CategorySubscription[] {

            };

            context.CategorySubscriptions.AddOrUpdate(
                record => new { record.CategoryID, record.UserID },
                categorySubscriptions
            );

            Reminder[] reminders = new Reminder[] {

            };

            context.Reminders.AddOrUpdate(
                record => new { record.SubscriptionID, record.IsActive, record.DateTime },
                reminders
            );

            Subscription[] subscriptions = new Subscription[] {

            };

            context.Subscriptions.AddOrUpdate(
                record => new { record.EventID, record.UserID },
                subscriptions
            );

            context.SaveChanges();
        }
    }
}
