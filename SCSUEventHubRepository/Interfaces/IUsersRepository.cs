using Microsoft.AspNet.Identity.EntityFramework;
using SCSUEventHubModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCSUEventHubRepository.Interfaces
{
    public interface IUsersRepository
    {
        IEnumerable<Admin> Admins { get; }
        IEnumerable<User> Users { get; }
        IEnumerable<IdentityRole> Roles { get; }
        Admin FindAdminById(string adminId);
        User FindUserById(string userId);
        IList<string> FindRolesForAccount(string userId);
        bool AddAdmin(Admin modelObject);
        bool AddUser(User modelObject);
        bool UpdateAdmin(Admin modelObject);
        bool UpdateUser(User modelObject);
        bool DeleteAdmin(string adminId);
        bool AdminAddRole(string adminId, string role);
        bool AdminRemoveRole(string adminId, string role);
        bool SyncAdminRoles(Admin modelObject);
        Dictionary<string, object> RolesForUser(Account user);
    }
}
