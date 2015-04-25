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
            }
            catch (Exception e)
            {
                dEvents = null;
                throw new Exception(e.Message);
            }

            return dEvents;
        }

        public int? UpdateEvent(Event updatedEvent)
        {
            var updatedEventID = new int?();

            try
            {
                if (null != updatedEvent)
                {

                }
                else updatedEventID = null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return updatedEventID;
        }

        public bool DeleteEvent(int eventID)
        {
            var success = false;

            try
            {

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
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return newSubscription;
        }

        public bool UnsubscribeFromEvent(int userID, int eventID)
        {
            var success = false;

            try
            {
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return success;
        }

        public Subscription GetSubscription(int eventID)
        {
            var subscription = new Subscription();

            try
            {
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return subscription;
        }

        public int? AddReminder(int userID, int eventID, Reminder reminder)
        {
            var reminderID = new int?();

            try
            {
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return reminderID;
        }

        public Reminder GetReminder(int reminderID)
        {
            var reminder = new Reminder();

            try
            {
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return reminder;
        }

        public List<Reminder> GetReminders(int eventID)
        {
            var reminders = new List<Reminder>();

            try
            {
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return reminders;
        }

        public int? UpdateReminder(int reminderID, Reminder reminder)
        {
            var updatedReminderID = new int?();

            try
            {
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return updatedReminderID;
        }

        public bool DeleteReminder(int reminderID)
        {
            var success = false;

            try
            {
            }
            catch (Exception e)
            {
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
