using REPO_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPO_Service.Service_Interface
{
    public interface IAccountService
    {
        Task<RolesDTO> login(string username, string password);
    }
}
