using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCSUEventHubModels.Models
{
    public class Admin : Account
    {
        public int RoleID { get; set; }
    }
}
