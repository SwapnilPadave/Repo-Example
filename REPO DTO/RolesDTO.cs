using REPO_MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPO_DTO
{
    public class RolesDTO :Role
    {
        public string UserName { get; set; }
        public string password { get; set; }
    }
}
