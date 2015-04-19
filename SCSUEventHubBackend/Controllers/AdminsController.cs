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
            throw new NotImplementedException();
        }

        // GET: Admins/Details/5
        public ActionResult Details(string id)
        {
            throw new NotImplementedException();
        }

        // GET: Admins/Create
        public ActionResult Create()
        {
            throw new NotImplementedException();
        }

        // POST: Admins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] Admin admin)
        {
            throw new NotImplementedException();
        }

        // GET: Admins/Edit/5
        public ActionResult Edit(string id)
        {
            throw new NotImplementedException();
        }

        // POST: Admins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] Admin admin)
        {
            throw new NotImplementedException();
        }

        // GET: Admins/Delete/5
        public ActionResult Delete(string id)
        {
            throw new NotImplementedException();
        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            throw new NotImplementedException();
        }
    }
}
