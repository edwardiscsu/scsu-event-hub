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

        public UsersRepository(EventHubDBEntities contextParam) : base(contextParam)
        {
            UserManager<Account> userManager = new UserManager<Account>(new UserStore<Account>(DBContext));
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(DBContext));
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

        public bool AddAdmin(Admin modelObject)
        {
            throw new NotImplementedException();
        }

        public bool AddUser(User modelObject)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAdmin(Admin modelObject)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(User modelObject)
        {
            throw new NotImplementedException();
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

        protected virtual void Dispose(bool disposing)
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
