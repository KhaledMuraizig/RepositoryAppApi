using System.ComponentModel.DataAnnotations;

namespace RepositoryApp_Api_.DTOs
{
    public class RoleDTO
    {
        public string RoleId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
