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
                return DBContext.Admins; 
            } 
        }

        public IEnumerable<User> Users
        {
            get
            {
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

        public bool AddAdmin(Admin modelObject, string password)
        {
            IdentityResult result = userManager.Create(modelObject, password);
            return result.Succeeded;
        }

        public bool AddUser(User modelObject, string password)
        {
            IdentityResult result = userManager.Create(modelObject, password);
            return result.Succeeded;
        }

        public bool UpdateAdmin(Admin modelObject)
        {
            IdentityResult result = userManager.Update(modelObject);
            return result.Succeeded;
        }

        public bool UpdateUser(User modelObject)
        {
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
