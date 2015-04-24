using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SCSUEventHubModels.Models;
using SCSUEventHubRepository.CategoriesRepositories;
using SCSUEventHubRepository.Interfaces;


namespace SCSUEventHubBackend.Controllers
{
    [Authorize(Roles = "T1 Administrator")]
    public class AdminsController : Controller
    {
        private IUsersRepository repository = new UsersRepository();

        // GET: Admins
        public ActionResult Index()
        {
            return View(repository.Admins.ToList());
        }

        // GET: Admins/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                Admin admin = repository.FindAdminById(id);
                if (admin == null)
                {
                    return HttpNotFound();
                }
                return View(admin);
            }
        }

        // GET: Admins/Create
        public ActionResult Create()
        {
            ViewBag.Roles = repository.RolesForUser(null);
            return View();
        }

        // POST: Admins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,LastName,Email,Password,PhoneNumber,RoleNames")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                repository.AddAdmin(admin);
                return RedirectToAction("Index");
            }
            ViewBag.Roles = repository.RolesForUser(admin);
            return View(admin);
        }

        // GET: Admins/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                Admin admin = repository.FindAdminById(id);
                if (admin == null)
                {
                    return HttpNotFound();
                }
                ViewBag.Roles = repository.RolesForUser(admin);
                return View(admin);
            }
        }

        // POST: Admins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,EmailConfirmed,Password,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,RoleNames")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateAdmin(admin);
                return RedirectToAction("Index");
            }
            ViewBag.Roles = repository.RolesForUser(admin);
            return View(admin);
        }

        // GET: Admins/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                Admin admin = repository.FindAdminById(id);
                if (admin == null)
                {
                    return HttpNotFound();
                }
                return View(admin);
            }
        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            repository.DeleteAdmin(id);
            return RedirectToAction("Index");
        }
    }
}
