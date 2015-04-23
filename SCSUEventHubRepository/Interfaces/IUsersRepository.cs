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
        Admin FindAdminById(string adminId);
        User FindUserById(string userId);
        IList<string> FindRolesForAccount(string userId);
        bool AddAdmin(Admin modelObject);
        bool AddUser(User modelObject);
        bool UpdateAdmin(Admin modelObject);
        bool UpdateUser(User modelObject);
        bool DeleteAdmin(string adminId);
        bool AdminAddRole(string adminId, string roleId);
        bool AdminRemoveRole(string adminId, string roleId);
    }
}
