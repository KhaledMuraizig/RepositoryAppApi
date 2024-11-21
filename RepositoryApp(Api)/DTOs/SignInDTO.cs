using System.ComponentModel.DataAnnotations;

namespace RepositoryApp_Api_.DTOs
{
    public class SignInDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
