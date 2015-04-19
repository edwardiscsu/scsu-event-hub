using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SCSUEventHubModels.Models;
using SCSUEventHubRepository.Entity;
using SCSUEventHubRepository.Interfaces;
using SCSUEventHubRepository.EventsRepositories;

namespace SCSUEventHubBackend.Controllers
{
    [Authorize(Roles = "T1 Administrator")]
    public class EventsController : Controller
    {
        private IEventsRepository repository = new EventsRepository();

        // GET: Events
        public ActionResult Index()
        {
            throw new NotImplementedException();
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            throw new NotImplementedException();
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            throw new NotImplementedException();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CategoryID,AdminID,EventName,DateTime,ImageURL,Description")] Event @event)
        {
            throw new NotImplementedException();
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            throw new NotImplementedException();
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CategoryID,AdminID,EventName,DateTime,ImageURL,Description")] Event @event)
        {
            throw new NotImplementedException();
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            throw new NotImplementedException();
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            throw new NotImplementedException();
        }
    }
}
