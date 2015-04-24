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

        public IEnumerable<IdentityRole> Roles
        {
            get
            {
                return roleManager.Roles;
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
            if (result.Succeeded)
            {
                return SyncAdminRoles(modelObject);
            }
            else
            {
                return false;
            }
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
            Admin record = DBContext.Admins.Find(modelObject.Id);
            record.CopyAttributes(modelObject);
            IdentityResult result = userManager.Update(record);
            if (result.Succeeded)
            {
                return SyncAdminRoles(record);
            }
            else
            {
                return false;
            }
        }

        public bool UpdateUser(User modelObject)
        {
            if (modelObject.Password != null)
            {
                modelObject.PasswordHash = userManager.PasswordHasher.HashPassword(modelObject.Password);
            }
            User record = DBContext.ClientUsers.Find(modelObject.Id);
            record.CopyAttributes(modelObject);
            IdentityResult result = userManager.Update(record);
            return result.Succeeded;
        }

        public bool DeleteAdmin(string adminId)
        {
            Admin user = DBContext.Admins.Find(adminId);
            IdentityResult result = userManager.Delete(user);
            return result.Succeeded;
        }

        public bool AdminAddRole(string adminId, string role)
        {
            IdentityResult result = userManager.AddToRole(adminId, role);
            return result.Succeeded;
        }

        public bool AdminRemoveRole(string adminId, string role)
        {
            IdentityResult result = userManager.RemoveFromRole(adminId, role);
            return result.Succeeded;
        }

        public bool SyncAdminRoles(Admin modelObject)
        {
            foreach (IdentityRole role in Roles)
            {
                if (modelObject.RoleNames.Contains(role.Name) && modelObject.Roles.SingleOrDefault(r => r.RoleId == role.Id) == null)
                {
                    if (!AdminAddRole(modelObject.Id, role.Name))
                    {
                        return false;
                    }
                }
                else if (!modelObject.RoleNames.Contains(role.Name) && modelObject.Roles.SingleOrDefault(r => r.RoleId == role.Id) != null)
                {
                    if (!AdminRemoveRole(modelObject.Id, role.Name))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public Dictionary<string, object> RolesForUser(Account user)
        {
            Dictionary<string, object> roleMap = new Dictionary<string, object>();
            foreach (IdentityRole role in Roles)
            {
                if (user != null && user.Roles.SingleOrDefault(r => r.RoleId == role.Id) != null)
                {
                    roleMap.Add(role.Name, new { value = role.Name, @checked = "checked" });
                }
                else 
                {
                    roleMap.Add(role.Name, new { value = role.Name });
                }
            }
            return roleMap;
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
