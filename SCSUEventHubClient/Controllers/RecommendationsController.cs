using SCSUEventHubRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCSUEventHubClient.Controllers
{
    public class RecommendationsController : Controller
    {
        private IRecommendationsRepository reccomendationsRepository;

        public RecommendationsController(IRecommendationsRepository reccomendationsRepository)
        {
            this.reccomendationsRepository = reccomendationsRepository;
        }


        public ActionResult Index()
        {
            return View();
        }

    }
}
