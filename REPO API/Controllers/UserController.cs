using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using REPO_MODEL;
using REPO_Service.Service_Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace REPO_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> getUserList()
        {
            IEnumerable<User> user = await _userService.GetAllUser();
            return Ok(user);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            return Ok(await _userService.AddUser(user));
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateUser(User user)
        {
            return Ok(await _userService.UpdateUser(user));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            return Ok(await _userService.DeleteUser(id));
        }
    }
}
