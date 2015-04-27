using SCSUEventHubRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCSUEventHubClient.Controllers
{
    public class UsersController : Controller
    {
        private IUsersRepository usersRepository;

        public UsersController(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }


        public ActionResult Index()
        {
            return View();
        }

    }
}
