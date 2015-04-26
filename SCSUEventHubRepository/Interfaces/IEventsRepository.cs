using SCSUEventHubModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCSUEventHubRepository.Interfaces
{
    public interface IEventsRepository
    {
        int? AddEvent(int adminID, Event newEvent);

        Event GetEvent(int eventID);
        List<Event> GetEvents(int? userID = null, int? categoryID = null, int? adminID = null);

        int? UpdateEvent(Event updatedEvent);

        bool DeleteEvent(int eventID);


        Subscription SubscribeToEvent(int userID, int eventID, ICollection<Reminder> reminders);
        bool UnsubscribeFromEvent(int userID, int eventID);

        Subscription GetSubscription(int userID, int eventID);


        int? AddReminder(int userID, int eventID, Reminder reminder);

        Reminder GetReminder(int reminderID);
        List<Reminder> GetReminders(int subscriptionID);

        int? UpdateReminder(int reminderID, Reminder reminder);

        bool DeleteReminder(int reminderID);
    }
}
