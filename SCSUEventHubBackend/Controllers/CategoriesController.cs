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
    public class CategoriesController : Controller
    {
        private ICategoriesRepository repository = new CategoriesRepository();

        // GET: Categories
        public ActionResult Index()
        {
            return View(repository.Categories.ToList());
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                Category category = repository.FindCategoryById(id.Value);
                if (category == null)
                {
                    return HttpNotFound();
                }
                return View(category);
            }
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AdminID,CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {
                repository.AddCategory(category);
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                Category category = repository.FindCategoryById(id.Value);
                if (category == null)
                {
                    return HttpNotFound();
                }
                return View(category);
            }
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AdminID,CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateCategory(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                Category category = repository.FindCategoryById(id.Value);
                if (category == null)
                {
                    return HttpNotFound();
                }
                return View(category);
            }
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repository.DeleteCategory(id);
            return RedirectToAction("Index");
        }
    }
}
