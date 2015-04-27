using SCSUEventHubModels.Models;
using SCSUEventHubRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCSUEventHubClient.Controllers
{
    public class EventsController : Controller
    {
        private IEventsRepository eventsRepository;

        public EventsController(IEventsRepository eventsRepository)
        {
            this.eventsRepository = eventsRepository;
        }


        public ActionResult Index()
        {
            return View();
        }


        // GET: Events/Get/?userID=1&categoryID=2&adminID=3
        public List<Event> Get(int? userID = null, int? categoryID = null, int? adminID = null)
        {
            var events = new List<Event>();

            try
            {
                events = eventsRepository.GetEvents(userID, categoryID, adminID);
            }
            catch (Exception e)
            {
                throw new HttpException(e.Message);
            }

            return events;
        }
    }
}
