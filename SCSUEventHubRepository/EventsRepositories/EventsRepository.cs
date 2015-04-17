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
    public class EventsRepository : IEventsRepository
    {
        public int? AddEvent(int adminID, Event newEvent)
        {
            int? newEventID = new int?();

            try
            {
                var eventHubDB = new Entity.EventHubDBEntities();
                AppDomain.CurrentDomain.SetData("DataDirectory",
                    PathFactory.DatabasePath());

                if (null != newEvent)
                {
                    //var eEvent = MapEventToEntity(newEvent);
                    //eventHubDB.Events.Add(eEvent);
                    //eventHubDB.SaveChanges();
                    //newEventID = eEvent.ID;
                    eventHubDB.Events.Add(newEvent);
                    eventHubDB.SaveChanges();
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
            throw new NotImplementedException();
        }

        public List<Event> GetEvents(int? userID = null, int? categoryID = null, int? adminID = null)
        {
            throw new NotImplementedException();
        }

        public int? UpdateEvent(Event updatedEvent)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEvent(int eventID)
        {
            throw new NotImplementedException();
        }

        public Subscription SubscribeToEvent(int userID, int eventID, ICollection<Reminder> reminders)
        {
            throw new NotImplementedException();
        }

        public bool UnsubscribeFromEvent(int userID, int eventID)
        {
            throw new NotImplementedException();
        }

        public Subscription GetSubscription(int eventID)
        {
            throw new NotImplementedException();
        }

        public int? AddReminder(int userID, int eventID, Reminder reminder)
        {
            throw new NotImplementedException();
        }

        public Reminder GetReminder(int reminderID)
        {
            throw new NotImplementedException();
        }

        public List<Reminder> GetReminders(int eventID)
        {
            throw new NotImplementedException();
        }

        public int? UpdateReminder(int reminderID, Reminder reminder)
        {
            throw new NotImplementedException();
        }

        public bool DeleteReminder(int reminderID)
        {
            throw new NotImplementedException();
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
