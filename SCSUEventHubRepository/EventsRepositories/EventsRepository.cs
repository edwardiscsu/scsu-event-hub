using SCSUEventHubRepository.Interfaces;
using SCSUEventHubModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCSUEventHubCommon.Tools;

namespace SCSUEventHubRepository.EventsRepositories
{
    public class EventsRepository : ContextDisposableRespository, IEventsRepository
    {
        public int? AddEvent(int adminID, Event newEvent)
        {
            int? newEventID = new int?();

            try
            {
                if (null != newEvent)
                {
                    DBContext.Events.Add(newEvent);
                    DBContext.SaveChanges();
                    newEventID = newEvent.ID;
                }
                else newEventID = new int?();
            }
            catch (Exception e)
            {
                newEventID = new int?();
                throw new Exception(e.Message);
            }

            return newEventID;
        }

        public Event GetEvent(int eventID)
        {
            var dEvent = new Event();

            try
            {
                dEvent = DBContext.Events
                    .Where(e => e.ID == eventID).FirstOrDefault();
            }
            catch (Exception e)
            {
                dEvent = null;
                throw new Exception(e.Message);
            }

            return dEvent;
        }

        public List<Event> GetEvents(int? userID = null, int? categoryID = null, int? adminID = null)
        {
            var dEvents = new List<Event>();

            try
            {
                if (null != userID)
                {
                    var subscribedIds = DBContext.Subscriptions
                        .Where(s => s.UserID == userID.Value).Select(s => s.EventID);
                    dEvents = DBContext.Events
                        .Where(e => subscribedIds.Contains(e.ID))
                        .Where(e => (categoryID.HasValue ? e.CategoryID == categoryID.Value : e.ID == e.ID)
                                    && (adminID.HasValue ? e.AdminID == adminID.Value : e.ID == e.ID))
                                    .ToList();
                }
                else
                {
                    dEvents = DBContext.Events
                        .Where(e => (categoryID.HasValue ? e.CategoryID == categoryID.Value : e.ID == e.ID)
                                    && (adminID.HasValue ? e.AdminID == adminID.Value : e.ID == e.ID))
                                    .ToList();
                }

                //Temp: Clean up the relational items
                foreach (var dEvent in dEvents)
                {
                    dEvent.Category = null;
                    dEvent.Admin = null;
                    dEvent.Recommendations = null;
                    dEvent.Subscriptions = null;
                }
            }
            catch (Exception e)
            {
                dEvents = null;
                throw new Exception(e.Message);
            }

            return dEvents;
        }

        public int? UpdateEvent(Event updEvent)
        {
            var updEventID = new int?();

            try
            {
                if (null != updEvent
                    && null != DBContext.Events.Find(updEvent.ID))
                {
                    var dEvent = DBContext.Events.Find(updEvent.ID);

                    dEvent.EventName = null != updEvent.EventName ? updEvent.EventName : dEvent.EventName;
                    dEvent.ImageURL = null != updEvent.ImageURL ? updEvent.ImageURL : dEvent.ImageURL;
                    dEvent.DateTime = null != updEvent.DateTime ? updEvent.DateTime : dEvent.DateTime;
                    dEvent.Description = null != updEvent.Description ? updEvent.Description : dEvent.Description;

                    dEvent.CategoryID = null != updEvent.CategoryID ? updEvent.CategoryID : dEvent.CategoryID;

                    DBContext.SaveChanges();

                    updEventID = updEvent.ID;
                }
                else updEventID = null;
            }
            catch (Exception e)
            {
                updEventID = null;
                throw new Exception(e.Message);
            }

            return updEventID;
        }

        public bool DeleteEvent(int eventID)
        {
            var success = false;

            try
            {
                var dEvent = DBContext.Events.Find(eventID);
                if (null != dEvent)
                    DBContext.Events.Remove(dEvent);
                DBContext.SaveChanges();

                success = true;
            }
            catch (Exception e)
            {
                success = false;
                throw new Exception(e.Message);
            }

            return success;
        }

        public Subscription SubscribeToEvent(int userID, int eventID, ICollection<Reminder> reminders)
        {
            var newSubscription = new Subscription();

            try
            {
                if (null != reminders
                    && null != DBContext.Users.Find(userID)
                    && null != DBContext.Events.Find(eventID))
                {
                    newSubscription.EventID = eventID;
                    newSubscription.UserID = userID;

                    DBContext.Subscriptions.Add(newSubscription);

                    foreach (var reminder in reminders)
                    {
                        var newRemID = AddReminder(userID, eventID, reminder);
                        if (null == newRemID) throw new Exception("error adding reminder");
                    }
                }
                else newSubscription = null;
            }
            catch (Exception e)
            {
                newSubscription = null;
                throw new Exception(e.Message);
            }

            return newSubscription;
        }

        public bool UnsubscribeFromEvent(int userID, int eventID)
        {
            var success = false;

            try
            {
                if (null != DBContext.Users.Find(userID)
                    && null != DBContext.Events.Find(eventID))
                {
                    var subscription = DBContext.Subscriptions
                        .Where(s => s.UserID == userID && s.EventID == eventID).FirstOrDefault();
                    
                    if (null != subscription)
                    {
                        var reminders = DBContext.Reminders
                            .Where(r => r.SubscriptionID == subscription.ID);

                        if (null != reminders)
                        {
                            DBContext.Reminders.RemoveRange(reminders);
                            DBContext.SaveChanges();
                        }

                        DBContext.Subscriptions.Remove(subscription);
                        DBContext.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                success = false;
                throw new Exception(e.Message);
            }

            return success;
        }

        public Subscription GetSubscription(int userID, int eventID)
        {
            var subscription = new Subscription();

            try
            {
                subscription = DBContext.Subscriptions
                    .Where(s => s.UserID == userID && s.EventID == eventID).FirstOrDefault();
            }
            catch (Exception e)
            {
                subscription = null;
                throw new Exception(e.Message);
            }

            return subscription;
        }

        public int? AddReminder(int userID, int eventID, Reminder reminder)
        {
            var reminderID = new int?();

            try
            {
                var subscription = GetSubscription(userID, eventID);
                if (null != subscription)
                {
                    reminder.SubscriptionID = subscription.ID;
                    DBContext.Reminders.Add(reminder);

                    DBContext.SaveChanges();
                }
                else reminderID = null;
            }
            catch (Exception e)
            {
                reminderID = null;
                throw new Exception(e.Message);
            }

            return reminderID;
        }

        public Reminder GetReminder(int reminderID)
        {
            var reminder = new Reminder();

            try
            {
                reminder = DBContext.Reminders.Find(reminderID);
            }
            catch (Exception e)
            {
                reminder = null;
                throw new Exception(e.Message);
            }

            return reminder;
        }

        public List<Reminder> GetReminders(int subscriptionID)
        {
            var reminders = new List<Reminder>();

            try
            {
                reminders = DBContext.Reminders
                    .Where(r => r.SubscriptionID == subscriptionID).ToList();
            }
            catch (Exception e)
            {
                reminders = null;
                throw new Exception(e.Message);
            }

            return reminders;
        }

        public int? UpdateReminder(int reminderID, Reminder reminder)
        {
            var updatedReminderID = new int?();

            try
            {
                var dReminder = DBContext.Reminders.Find(reminderID);
                if (null != dReminder)
                {
                    dReminder.IsActive = null != reminder.IsActive ? reminder.IsActive : dReminder.IsActive;
                    dReminder.DateTime = null != reminder.DateTime ? reminder.DateTime : dReminder.DateTime;

                    DBContext.SaveChanges();

                    updatedReminderID = dReminder.ID;
                }
                else updatedReminderID = null;
            }
            catch (Exception e)
            {
                updatedReminderID = null;
                throw new Exception(e.Message);
            }

            return updatedReminderID;
        }

        public bool DeleteReminder(int reminderID)
        {
            var success = false;

            try
            {
                var reminder = DBContext.Reminders.Find(reminderID);
                if (null != reminder)
                {
                    DBContext.Reminders.Remove(reminder);
                    DBContext.SaveChanges();
                }

                success = true;
            }
            catch (Exception e)
            {
                success = false;
                throw new Exception(e.Message);
            }

            return success;
        }
        /*

        #region Mapping

        private Entity.Event MapEventToEntity(Event mEvent)
        {
            var eEvent = new Entity.Event();

            if (null != mEvent)
            {
                eEvent.ID = mEvent.ID;
                eEvent.CategoryID = mEvent.CategoryID;
                eEvent.AdminID = mEvent.AdminID;

                eEvent.EventName = mEvent.EventName;
                eEvent.Description = mEvent.Description;
                eEvent.DateTime = mEvent.EventDateTime;
                eEvent.ImageURL = mEvent.ImageURL;
            }
            else eEvent = null;

            return eEvent;
        }

        private Event MapEntityToEvent(Entity.Event eEvent)
        {
            var mEvent = new Event();

            if (null != eEvent)
            {
                mEvent.ID = eEvent.ID;
                mEvent.CategoryID = eEvent.CategoryID.HasValue ? eEvent.CategoryID.Value : 0;
                mEvent.AdminID = eEvent.AdminID.HasValue ? eEvent.AdminID.Value : 0;

                mEvent.EventName = eEvent.EventName;
                mEvent.Description = eEvent.Description;
                mEvent.EventDateTime = eEvent.DateTime.HasValue ? eEvent.DateTime.Value : DateTime.MinValue;
                mEvent.ImageURL = eEvent.ImageURL;
            }
            else mEvent = null;

            return mEvent;
        }

        #endregion
         * */
    }
}
