using SCSUEventHubClient.Models;
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
        public JsonResult Get(int? userID = null, int? categoryID = null, int? adminID = null)
        {
            var mEvents = new List<EventModel>();

            try
            {
                var dEvents = eventsRepository.GetEvents(userID, categoryID, adminID);
                if (null != dEvents)
                    foreach (var dEvent in dEvents)
                        mEvents.Add(MapEventToEventModel(dEvent));
            }
            catch (Exception e)
            {
                throw new HttpException(e.Message);
            }

            return Json(mEvents, JsonRequestBehavior.AllowGet);
        }


        #region Mapper

        private EventModel MapEventToEventModel(Event dEvent)
        {
            var mEvent = new EventModel();

            mEvent.ID = dEvent.ID;
            mEvent.CategoryID = dEvent.CategoryID;
            mEvent.AdminID = dEvent.AdminID;

            mEvent.EventName = dEvent.EventName;
            mEvent.Date = dEvent.DateTime.Value.Date.ToString();
            mEvent.Time = dEvent.DateTime.Value.TimeOfDay.ToString();
            mEvent.ImageURL = dEvent.ImageURL;
            mEvent.Description = dEvent.Description;

            return mEvent;
        }

        #endregion
    }
}
