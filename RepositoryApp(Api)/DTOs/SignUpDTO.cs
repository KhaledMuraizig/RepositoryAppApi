using System.ComponentModel.DataAnnotations;

namespace RepositoryApp_Api_.DTOs
{
    public class SignUpDTO
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string RoleName { get; set; }
    }
}
