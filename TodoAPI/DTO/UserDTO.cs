using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;

namespace TodoAPI.DTO
{
    public class UserDTO
    {
        [MaxLength(200)]
        [Required]
        public string Name { get; set; }
        [Email]
        public string? Email { get; set; }

    }
}
