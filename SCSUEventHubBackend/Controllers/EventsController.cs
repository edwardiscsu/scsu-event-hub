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
using SCSUEventHubRepository.CategoriesRepositories;

namespace SCSUEventHubBackend.Controllers
{
    [Authorize(Roles = "T1 Administrator")]
    public class EventsController : Controller
    {
        private IEventsRepository repository = new EventsRepository();

        // GET: Events
        public ActionResult Index()
        {
            return View(repository.GetEvents());
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            var dEvent = new Event();

            try
            {
                if (null != id)
                {
                    dEvent = repository.GetEvent(id.Value);
                }
                else dEvent = null;
            }
            catch (Exception e)
            {
                dEvent = null;
                throw new HttpException(400, e.Message);
            }

            return View(dEvent);
        }

        // GET: Events/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CategoryID,AdminID,EventName,DateTime,ImageURL,Description")] Event @event)
        {
            if (ModelState.IsValid)
            {
                repository.AddEvent(@event.AdminID.Value, @event);
                return RedirectToAction("Index");
            }

            return View(@event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var dEvent = repository.GetEvent(id.Value);
                if (dEvent == null)
                {
                    return HttpNotFound();
                }
                ViewBag.UserId = new SelectList((new UsersRepository()).Admins, "Id", "Email");
                return View(dEvent);
            }
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CategoryID,AdminID,EventName,DateTime,ImageURL,Description")] Event @event)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateEvent(@event);
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList((new UsersRepository()).Admins, "Id", "Email", @event.AdminID);
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var @event = repository.GetEvent(id.Value);
                if (@event == null)
                {
                    return HttpNotFound();
                }
                return View(@event);
            }
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repository.DeleteEvent(id);
            return RedirectToAction("Index");
        }
    }
}
