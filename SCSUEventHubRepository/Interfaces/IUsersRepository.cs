using SCSUEventHubRepository.Entity;
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
        Admin FindAdminById(int adminId);
        User FindUserById(int userId);
        bool AddAdmin(Admin modelObject);
        bool AddUser(User modelObject);
        bool UpdateAdmin(Admin modelObject);
        bool UpdateUser(User modelObject);
        bool DeleteAdmin(int adminId);
        bool AdminAddRole(int roleId);
        bool AdminRemoveRole(int roleId);
    }
}
