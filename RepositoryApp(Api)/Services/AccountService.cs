using Microsoft.AspNetCore.Identity;
using RepositoryApp_Api_.Data;
using RepositoryApp_Api_.DTOs;

namespace RepositoryApp_Api_.Services
{
    public class AccountService : IAccountService
    {
        Context context;
        UserManager<User> userManager;
        RoleManager<IdentityRole> roleManager;
        SignInManager<User> signInManager;

        public AccountService(Context _context, UserManager<User> _userManager,
                                RoleManager<IdentityRole> _roleManager, SignInManager<User> _signInManager)
        {
            context = _context;
            userManager = _userManager;
            roleManager = _roleManager;
            signInManager = _signInManager;
        }

        public async Task<bool> CreatUser(SignUpDTO signUpDTO)
        {
            bool IsSuccess = true;

            User user = new User();

            user.FirstName = signUpDTO.FirstName;
            user.LastName = signUpDTO.LastName;
            user.Email = signUpDTO.Email;
            user.UserName = signUpDTO.Username;

            var CreateResult = await userManager.CreateAsync(user, signUpDTO.Password);

            if (CreateResult.Succeeded)
            {
                var RoleResult = await userManager.AddToRoleAsync(user, signUpDTO.RoleName);
                {
                    if (!RoleResult.Succeeded)
                    {
                        await userManager.DeleteAsync(user);
                        IsSuccess = false;

                    }
                }
            }
            else
            {
                IsSuccess = false;
            }
            return IsSuccess;
        }

        public async Task<SignInResult> Login(SignInDTO signInDTO)
        {
            var Result = await signInManager.PasswordSignInAsync(signInDTO.Username, signInDTO.Password, false, false);
            return Result;
        }

        public async Task<IdentityResult> AddRole(RoleDTO roleDTO)
        {
            IdentityRole role = new IdentityRole();
            role.Name = roleDTO.Name;

            var Result = await roleManager.CreateAsync(role);

            return Result;
        }

        public List<RoleDTO> GetRoles()
        {
            List<IdentityRole> roles = roleManager.Roles.ToList();
            List<RoleDTO> rolesDTO = new List<RoleDTO>();

            foreach (IdentityRole role in roles)
            {
                RoleDTO roleDTO = new RoleDTO();
                roleDTO.Name = role.Name;
                roleDTO.RoleId = role.Id;
                rolesDTO.Add(roleDTO);
            }

            return rolesDTO;
        }

        public List<UserDTO> GetUsers()
        {
            List<User> users = userManager.Users.ToList();
            List<UserDTO> userDTOs = new List<UserDTO>();

            foreach (User user in users)
            {
                UserDTO userDTO = new UserDTO();
                userDTO.FirstName = user.FirstName;
                userDTO.LastName = user.LastName;
                userDTO.Username = user.UserName;
                userDTO.Email = user.Email;

                userDTOs.Add(userDTO);
            }

            return userDTOs;
        }

        public async Task<IList<string>> GetUserRole(string username)
        {
            var user = await userManager.FindByNameAsync(username);
            return await userManager.GetRolesAsync(user);
        }
    }
}
