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
                    Admin adminUser = new Admin() { UserName = "harlansang@gmail.com", Email = "harlansang@gmail.com" };
                    IdentityResult userResult = userManager.Create(adminUser, "scsu2015");
                    if (userResult.Succeeded)
                    {
                        IdentityResult result = userManager.AddToRole(adminUser.Id, roleT1);
                    }
                }

                if (roleResult.Succeeded)
                {
                    Admin adminUser = new Admin() { UserName = "ised0301@stcloudstate.edu", Email = "ised0301@stcloudstate.edu" };
                    IdentityResult userResult = userManager.Create(adminUser, "scsu2015");
                    if (userResult.Succeeded)
                    {
                        IdentityResult result = userManager.AddToRole(adminUser.Id, roleT1);
                    }
                }

                if (roleResult.Succeeded)
                {
                    Admin adminUser = new Admin() { UserName = "ehpr1301@stcloudstate.edu", Email = "ehpr1301@stcloudstate.edu" };
                    IdentityResult userResult = userManager.Create(adminUser, "scsu2015");
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

            context.SaveChanges();

            Event[] events = new Event[] {
                //Athletics
                new Event { CategoryID = categories[0].ID, EventName = "Hockey with Santa", DateTime = new DateTime(2015,5,6), ImageURL = "pic1.jpeg", Description = "Can you beat santa in ice hockey? Prove yourselves!" },
                new Event { CategoryID = categories[0].ID, EventName = "Atwood Game Night", DateTime = new DateTime(2015,6,1), ImageURL = "pic2.jpeg", Description = "Play pools and bowlings for free! Bring your friends!" },
                new Event { CategoryID = categories[0].ID, EventName = "Joust Your Friend", DateTime = new DateTime(2015,7,9), ImageURL = "pic3.jpeg", Description = "Learn a" },

                //Conferences & Workshops
                new Event { CategoryID = categories[1].ID, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,6,2), ImageURL = "pic1.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = categories[1].ID, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,6,8), ImageURL = "pic2.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = categories[1].ID, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,6,9), ImageURL = "pic3.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = categories[1].ID, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,7,2), ImageURL = "pic4.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = categories[1].ID, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,8,1), ImageURL = "pic5.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },

                //Cultural
                new Event { CategoryID = categories[2].ID, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,5,2), ImageURL = "pic1.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = categories[2].ID, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,5,6), ImageURL = "pic2.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = categories[2].ID, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,5,9), ImageURL = "pic3.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },

                //Entertainment
                new Event { CategoryID = categories[3].ID, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,5,6), ImageURL = "pic1.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = categories[3].ID, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,5,8), ImageURL = "pic2.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = categories[3].ID, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,6,1), ImageURL = "pic3.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = categories[3].ID, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,6,2), ImageURL = "pic4.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = categories[3].ID, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,7,2), ImageURL = "pic5.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = categories[3].ID, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,8,3), ImageURL = "pic1.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = categories[3].ID, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,8,2), ImageURL = "pic2.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = categories[3].ID, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,7,7), ImageURL = "pic3.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = categories[3].ID, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,6,4), ImageURL = "pic4.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = categories[3].ID, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,6,5), ImageURL = "pic5.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },

                //Fine Arts
                new Event { CategoryID = categories[4].ID, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,5,7), ImageURL = "pic1.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = categories[4].ID, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,6,8), ImageURL = "pic2.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = categories[4].ID, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,7,2), ImageURL = "pic3.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = categories[4].ID, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,7,3), ImageURL = "pic4.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = categories[4].ID, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,8,4), ImageURL = "pic5.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },

                //Recreation
                new Event { CategoryID = categories[5].ID, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,5,6), ImageURL = "pic1.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = categories[5].ID, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,6,6), ImageURL = "pic2.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = categories[5].ID, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,6,7), ImageURL = "pic3.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = categories[5].ID, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,7,1), ImageURL = "pic4.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = categories[5].ID, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,7,3), ImageURL = "pic5.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = categories[5].ID, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,7,5), ImageURL = "pic1.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },

                //Speakers
                new Event { CategoryID = categories[6].ID, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,5,4), ImageURL = "pic1.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = categories[6].ID, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,5,9), ImageURL = "pic2.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = categories[6].ID, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,6,2), ImageURL = "pic3.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },

                //Special Events
                new Event { CategoryID = categories[7].ID, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,5,6), ImageURL = "pic1.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = categories[7].ID, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,5,8), ImageURL = "pic2.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = categories[7].ID, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,6,1), ImageURL = "pic3.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = categories[7].ID, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,7,7), ImageURL = "pic4.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = categories[7].ID, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,8,1), ImageURL = "pic5.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." }
            };

            context.Events.AddOrUpdate(
                record => record.EventName,
                events
            );

            context.SaveChanges();

            Recommendation[] recommendations = new Recommendation[] {

            };

            context.Recommendations.AddOrUpdate(
                record => new { record.EventID, record.UserID },
                recommendations
            );

            context.SaveChanges();

            CategorySubscription[] categorySubscriptions = new CategorySubscription[] {

            };

            context.CategorySubscriptions.AddOrUpdate(
                record => new { record.CategoryID, record.UserID },
                categorySubscriptions
            );

            context.SaveChanges();

            Reminder[] reminders = new Reminder[] {

            };

            context.Reminders.AddOrUpdate(
                record => new { record.SubscriptionID, record.IsActive, record.DateTime },
                reminders
            );

            context.SaveChanges();

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
