using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoAPI.Models
{
    public class User 
    {
        public Guid ID { get; set; }
        public string Name { get; set; }

        [Column("EmailID")]
        [MaxLength(200)]
        public string Email { get; set; }

        public List<Todo> Todos { get; set; }   

        public User()
        {
        }

        public User(Guid iD, string name, string email)
        {
            ID = iD;
            Name = name;
            Email = email;
        }

        public override bool Equals(object? obj) // user
        {
            /*if(obj != null)
            {
                User usr = obj as User; //type casting
                if( usr.ID == this.ID )
                    return true;
                return false;
            }*/

            return obj is User user && ID.Equals(user.ID);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID, Name, Email);
        }

        public override string? ToString()
        {
            return $"User Object with Id: {this.ID}, Name: {this.Name}, Email: {this.Email}";
        }
    }
}
