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
            return new Event { CategoryID = 1, EventName = "Hockey with Santa", DateTime = new DateTime(2015, 5, 6), ImageURL = "pic1.jpeg", Description = "Can you beat santa in ice hockey? Prove yourselves!" };
        }

        public List<Event> GetEvents(int? userID = null, int? categoryID = null, int? adminID = null)
        {
            return new List<Event>()
            {
                new Event { CategoryID = 0, EventName = "Hockey with Santa", DateTime = new DateTime(2015,5,6), ImageURL = "pic1.jpeg", Description = "Can you beat santa in ice hockey? Prove yourselves!" },
                new Event { CategoryID = 0, EventName = "Atwood Game Night", DateTime = new DateTime(2015,6,1), ImageURL = "pic2.jpeg", Description = "Play pools and bowlings for free! Bring your friends!" },
                new Event { CategoryID = 0, EventName = "Joust Your Friend", DateTime = new DateTime(2015,7,9), ImageURL = "pic3.jpeg", Description = "Learn a" },

                //Conferences & Workshops
                new Event { CategoryID = 1, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,6,2), ImageURL = "pic1.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = 1, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,6,8), ImageURL = "pic2.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = 1, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,6,9), ImageURL = "pic3.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = 1, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,7,2), ImageURL = "pic4.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = 1, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,8,1), ImageURL = "pic5.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },

                //Cultural
                new Event { CategoryID = 2, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,5,2), ImageURL = "pic1.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = 2, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,5,6), ImageURL = "pic2.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = 2, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,5,9), ImageURL = "pic3.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },

                //Entertainment
                new Event { CategoryID = 3, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,5,6), ImageURL = "pic1.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = 3, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,5,8), ImageURL = "pic2.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = 3, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,6,1), ImageURL = "pic3.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = 3, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,6,2), ImageURL = "pic4.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = 3, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,7,2), ImageURL = "pic5.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = 3, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,8,3), ImageURL = "pic1.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = 3, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,8,2), ImageURL = "pic2.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = 3, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,7,7), ImageURL = "pic3.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = 3, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,6,4), ImageURL = "pic4.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = 3, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,6,5), ImageURL = "pic5.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },

                //Fine Arts
                new Event { CategoryID = 4, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,5,7), ImageURL = "pic1.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = 4, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,6,8), ImageURL = "pic2.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = 4, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,7,2), ImageURL = "pic3.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = 4, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,7,3), ImageURL = "pic4.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = 4, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,8,4), ImageURL = "pic5.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },

                //Recreation
                new Event { CategoryID = 5, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,5,6), ImageURL = "pic1.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = 5, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,6,6), ImageURL = "pic2.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = 5, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,6,7), ImageURL = "pic3.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = 5, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,7,1), ImageURL = "pic4.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = 5, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,7,3), ImageURL = "pic5.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = 5, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,7,5), ImageURL = "pic1.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },

                //Speakers
                new Event { CategoryID = 6, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,5,4), ImageURL = "pic1.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = 6, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,5,9), ImageURL = "pic2.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = 6, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,6,2), ImageURL = "pic3.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },

                //Special Events
                new Event { CategoryID = 7, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,5,6), ImageURL = "pic1.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = 7, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,5,8), ImageURL = "pic2.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = 7, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,6,1), ImageURL = "pic3.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = 7, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,7,7), ImageURL = "pic4.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." },
                new Event { CategoryID = 7, EventName = "History Night: Fu-Go", DateTime = new DateTime(2015,8,1), ImageURL = "pic5.jpeg", Description = "Learn about Fu-Go. The Japanese secret weapon in WWII." }
            };
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
