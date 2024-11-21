using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RepositoryApp_Api_.DTOs;
using RepositoryApp_Api_.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RepositoryApp_Api_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        IAccountService accountService;

        public AccountController(IAccountService _accountService)
        {
            accountService = _accountService;
        }

        [HttpPost]
        [Route("AddRole")]
        public async Task AddRole(RoleDTO roleDTO)
        {
            await accountService.AddRole(roleDTO);
        }

        [HttpGet]
        [Route("GetRoles")]
        public List<RoleDTO> GetRoles()
        {
            return accountService.GetRoles();
        }

        [HttpPost]
        [Route("CreatAccount")]
        public async Task CreatAccount(SignUpDTO signUpDTO)
        {
            await accountService.CreatUser(signUpDTO);
        }

        public async Task Login(SignInDTO signUpDTO)
        {
            await accountService.Login(signUpDTO);
        }

        [HttpGet]
        [Route("GetUsers")]
        public List<UserDTO> GetUsers()
        {
            return accountService.GetUsers();
        }
        [HttpPost]
        [Route("LogIn")]
        public async Task<IActionResult> LogIn(SignInDTO signInDTO)
        {
            var result = await accountService.Login(signInDTO);
            if (result.Succeeded)
            {
                List<Claim> authClaim = new List<Claim>();
                authClaim.Add(new Claim(ClaimTypes.Name, signInDTO.Username));
                authClaim.Add(new Claim("UniqueValue", Guid.NewGuid().ToString()));

                var userRoles = await accountService.GetUserRole(signInDTO.Username);

                foreach (var role in userRoles)
                {
                    authClaim.Add(new Claim(ClaimTypes.Role, role));
                }
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMyVerySecureAndLongerSecurityKey123!"));
                var token = new JwtSecurityToken(
                    issuer: "http://localhost",
                    audience: "User",
                    expires: DateTime.Now.AddDays(15),
                    claims: authClaim,
                    signingCredentials: new SigningCredentials(
                        authSigningKey,
                        SecurityAlgorithms.HmacSha256));
                return Ok(
                    new
                    {
                        tokenValue = new JwtSecurityTokenHandler().WriteToken(token)
                    });
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpGet]
        [Route("GetRolesByUsername")]
        public async Task<IList<string>> GetRolesByUsername(string username)
        {
            return await accountService.GetUserRole(username);
        }
    }
}
