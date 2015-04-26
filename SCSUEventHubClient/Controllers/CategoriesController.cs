using SCSUEventHubRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCSUEventHubClient.Controllers
{
    public class CategoriesController : Controller
    {
        private ICategoriesRepository categoriesRepository;

        public ActionResult Index()
        {
            return View();
        }

    }
}
