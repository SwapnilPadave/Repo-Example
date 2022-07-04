using REPO_DTO;
using REPO_Repository.Repositories;
using REPO_Service.Service_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPO_Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<RolesDTO> login(string username, string password)
        {
            return await _accountRepository.login(username, password);
        }
    }
}
