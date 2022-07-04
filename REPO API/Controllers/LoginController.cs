using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using REPO_DTO;
using REPO_Service.Service_Interface;
using System.Threading.Tasks;

namespace REPO_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _config;

        public LoginController(IAccountService accountService, ITokenService tokenService, IConfiguration config)
        {
            _accountService = accountService;
            _tokenService = tokenService;
            _config = config;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDTO LoginDTO)
        {
            RolesDTO _login = await _accountService.login(LoginDTO.UserName, LoginDTO.Password);

            if (_login == null)
            {
                return Unauthorized("Invalid Credentials");
            }
            var token = _tokenService.CreateToken(_login);
            return Ok(token);
        }
    }
}
