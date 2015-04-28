using Microsoft.AspNet.Identity;
using SCSUEventHubModels.Models;
using SCSUEventHubModels.ViewModels;
using SCSUEventHubRepository.CategoriesRepositories;
using SCSUEventHubRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace SCSUEventHubClient.Controllers
{
    public class UsersController : ApiController
    {
        private IUsersRepository usersRepository;

        public UsersController()
        {
            this.usersRepository = new UsersRepository();
        }

        public UsersController(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public IHttpActionResult Get(string email)
        {
            User user = usersRepository.FindUserByEmail(email);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        public IHttpActionResult Post(RegisterBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User user = new User() { UserName = model.Email, Email = model.Email, Password = model.Password };
            IdentityResult result = usersRepository.AddUser(user);
            if (result.Succeeded)
            {
                return Ok(user);
            }
            else
            {
                return GetErrorResult(result);
            }
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
