using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SCSUEventHubModels.Models
{
    public class Account : IdentityUser, IModelCopyable<Account>
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [NotMapped]
        [Display(Name = "Roles")]
        public IList<string> RoleNames { get; set; }

        [NotMapped]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Account> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public void CopyAttributes(Account other)
        {
            AccessFailedCount = other.AccessFailedCount;
            Email = other.Email;
            EmailConfirmed = other.EmailConfirmed;
            LockoutEnabled = other.LockoutEnabled;
            LockoutEndDateUtc = other.LockoutEndDateUtc;
            PasswordHash = other.PasswordHash;
            PhoneNumber = other.PhoneNumber;
            PhoneNumberConfirmed = other.PhoneNumberConfirmed;
            SecurityStamp = other.SecurityStamp;
            TwoFactorEnabled = other.TwoFactorEnabled;
            UserName = other.UserName;
            FirstName = other.FirstName;
            LastName = other.LastName;
            RoleNames = other.RoleNames;
        }
    }
}
