using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;



namespace Versta.Core.Models
{
    public class User
    {
        [Key]
        public Guid? Id { get; set; }            
        public string? UserName { get; set; } = "";
        public string? Email { get; set; } = "";
        public string? Role { get; set; } = "";  
        public bool? IsActive { get; set; } = false;
        public string? Token { get; set; } = "";
        public string? Password { get; set; } = "";   // PasswordHash
        public int? RoleId { get; set; }


        public User(string email, string password, string role) 
        {
            Email = email;
            Password = password;
            Role = role;
        }
    }
}
