namespace SCSUEventHubRepository.Migrations
{
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

            User[] users = new User[] {

            };

            context.Users.AddOrUpdate(
                record => record.Email,
                users
            );

            Admin[] admins = new Admin[] {

            };

            context.Admins.AddOrUpdate(
                record => record.Email,
                admins
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
