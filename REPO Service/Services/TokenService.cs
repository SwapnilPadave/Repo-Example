using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using REPO_DTO;
using REPO_Service.Service_Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace REPO_Service.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        private readonly IConfiguration _configuration;
        private readonly IAccountService _accountService;

        public TokenService(IConfiguration configuration, IAccountService accountService)
        {
            _configuration = configuration;
            _accountService = accountService;
        }

        public string CreateToken(RolesDTO rolesDTO)
        {
            var user = _accountService.login(rolesDTO.UserName, rolesDTO.password);
            var claims = new List<Claim>
            {

                new Claim(JwtRegisteredClaimNames.NameId, rolesDTO.UserName),
                new Claim("RoleID",rolesDTO.RoleId.ToString(), ClaimValueTypes.Integer),                
                new Claim(ClaimTypes.Role,rolesDTO.RoleName.ToString(),ClaimValueTypes.String)

            };
            var _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:TokenKey"]));
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["JWT:ValidIssuer"],
                Audience = _configuration["JWT:ValidAudience"],
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds

            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            //return ok
            return tokenHandler.WriteToken(token);
        }

    }
}
