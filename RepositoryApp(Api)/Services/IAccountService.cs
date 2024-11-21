using Microsoft.AspNetCore.Identity;
using RepositoryApp_Api_.DTOs;

namespace RepositoryApp_Api_.Services
{
    public interface IAccountService
    {
        Task<IdentityResult> AddRole(RoleDTO roleDTO);
        Task<bool> CreatUser(SignUpDTO signUpDTO);
        List<RoleDTO> GetRoles();
        Task<IList<string>> GetUserRole(string username);
        List<UserDTO> GetUsers();
        Task<SignInResult> Login(SignInDTO signInDTO);
    }
}