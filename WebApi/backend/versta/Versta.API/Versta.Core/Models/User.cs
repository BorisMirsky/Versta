using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Versta.Core.Models
{
    [Table("users")]
    public class User
    {
        public User()
        { }

        [Key]
        [Column("id")]
        public Guid? Id { get; set; }

        [Column("username")]
        public string? UserName { get; set; } = "";

        [Column("email")]
        public string? Email { get; set; } = "";

        [Column("role")]
        public string? Role { get; set; } = "";

        [Column("isactive")]
        public bool? IsActive { get; set; } = false;

        [Column("token")]
        public string? Token { get; set; } = "";

        [Column("password")]
        public string? Password { get; set; } = "";   // PasswordHash

        [Column("roleid")]
        public int? RoleId { get; set; }


        public User(string email, string password, string role) 
        {
            Email = email;
            Password = password;
            Role = role;
        }
    }
}
