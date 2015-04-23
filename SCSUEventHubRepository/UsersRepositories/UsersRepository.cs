using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SCSUEventHubModels.Models;
using SCSUEventHubRepository.Entity;
using SCSUEventHubRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCSUEventHubRepository.CategoriesRepositories
{
    public class UsersRepository : ContextDisposableRespository, IUsersRepository
    {
        private UserManager<Account> userManager;
        private RoleManager<IdentityRole> roleManager;
        private bool adminsLoaded = false;
        private bool usersLoaded = false;

        public UsersRepository()
            : base()
        {
            userManager = new UserManager<Account>(new UserStore<Account>(DBContext));
            roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(DBContext));
        }

        public IEnumerable<Admin> Admins 
        {
            get 
            {
                if (!adminsLoaded)
                {
                    foreach (Admin user in DBContext.Admins)
                    {
                        user.RoleNames = this.FindRolesForAccount(user.Id);
                    }
                    adminsLoaded = true;
                }
                return DBContext.Admins; 
            } 
        }

        public IEnumerable<User> Users
        {
            get
            {
                if (!usersLoaded)
                {
                    foreach (User user in DBContext.ClientUsers)
                    {
                        user.RoleNames = this.FindRolesForAccount(user.Id);
                    }
                    usersLoaded = true;
                }
                return DBContext.ClientUsers; 
            }
        }

        public Admin FindAdminById(string adminId)
        {
            Admin user = DBContext.Admins.Find(adminId);
            return user;
        }

        public User FindUserById(string userId)
        {
            User user = DBContext.ClientUsers.Find(userId);
            return user;
        }

        public IList<string> FindRolesForAccount(string userId)
        {
            return userManager.GetRoles<Account, string>(userId);
        }

        public bool AddAdmin(Admin modelObject)
        {
            modelObject.UserName = modelObject.Email;
            modelObject.EmailConfirmed = true;
            if (modelObject.PhoneNumber != null)
            {
                modelObject.PhoneNumberConfirmed = true;
            }
            
            IdentityResult result = userManager.Create(modelObject, modelObject.Password);
            return result.Succeeded;
        }

        public bool AddUser(User modelObject)
        {
            modelObject.UserName = modelObject.Email;
            IdentityResult result = userManager.Create(modelObject, modelObject.Password);
            return result.Succeeded;
        }

        public bool UpdateAdmin(Admin modelObject)
        {
            if (modelObject.Password != null)
            {
                modelObject.PasswordHash = userManager.PasswordHasher.HashPassword(modelObject.Password);
            }
            IdentityResult result = userManager.Update(modelObject);
            return result.Succeeded;
        }

        public bool UpdateUser(User modelObject)
        {
            if (modelObject.Password != null)
            {
                modelObject.PasswordHash = userManager.PasswordHasher.HashPassword(modelObject.Password);
            }
            IdentityResult result = userManager.Update(modelObject);
            return result.Succeeded;
        }

        public bool DeleteAdmin(string adminId)
        {
            Admin user = DBContext.Admins.Find(adminId);
            IdentityResult result = userManager.Delete(user);
            return result.Succeeded;
        }

        public bool AdminAddRole(string adminId, string roleId)
        {
            IdentityResult result = userManager.AddToRole(adminId, roleId);
            return result.Succeeded;
        }

        public bool AdminRemoveRole(string adminId, string roleId)
        {
            IdentityResult result = userManager.RemoveFromRole(adminId, roleId);
            return result.Succeeded;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                userManager.Dispose();
                roleManager.Dispose();
            }

            base.Dispose();
        }
    }
}
