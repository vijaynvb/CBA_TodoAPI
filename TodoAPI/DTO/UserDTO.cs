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

        public UserDTO(string name, string? email)
        {
            Name = name;
            Email = email;
        }

        public override string? ToString()
        {
            return "{ name: "+this.Name+", email: "+ this.Email+"}";
        }
    }
}
