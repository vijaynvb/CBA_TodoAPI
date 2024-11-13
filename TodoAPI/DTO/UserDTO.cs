using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;

namespace TodoAPI.DTO
{
    public class UserDTO
    {
        public Guid ID { get; set; }
        [Max(200)]
        [Required]
        public string Name { get; set; }
        [Email]
        public string? Email { get; set; }

    }
}
