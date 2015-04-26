using SCSUEventHubRepository.Interfaces;
using SCSUEventHubModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCSUEventHubRepository.EventsRepositories
{
    public class EventsRepositoryFake : IEventsRepository
    {
        public int? AddEvent(int adminID, Event newEvent)
        {
            throw new NotImplementedException();
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

        public Subscription GetSubscription(int userID, int eventID)
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

        public List<Reminder> GetReminders(int subscriptionID)
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
    }
}
