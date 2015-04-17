using SCSUEventHubModels.Models;
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
        public IEnumerable<Admin> Admins 
        {
            get 
            {
                throw new NotImplementedException();
            } 
        }

        public IEnumerable<User> Users
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Admin FindAdminById(int adminId)
        {
            throw new NotImplementedException();
        }

        public User FindUserById(int userId)
        {
            throw new NotImplementedException();
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

        public bool DeleteAdmin(int adminId)
        {
            throw new NotImplementedException();
        }

        public bool AdminAddRole(int roleId)
        {
            throw new NotImplementedException();
        }

        public bool AdminRemoveRole(int roleId)
        {
            throw new NotImplementedException();
        }
    }
}
