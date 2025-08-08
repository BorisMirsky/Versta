using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;



namespace Versta.Core.Models
{
    [Table("Users")]
    public class User
    {
        public User()
        { }

        [Key]
        [Column("id")]
        public Guid? Id { get; set; }

        [Column("username")]
        public string? UserName { get; set; }

        [Column("email")]
        public string Email { get; set; } = String.Empty;

        //public Role? Role { get; set; }

        [Column("role")]
        public string Rolename { get; set; } = String.Empty;

        [Column("roleid")]
        public int RoleId { get; set; } = 0;

        [Column("isactive")]
        public bool IsActive { get; set; } = false;

        [Column("token")]
        public string Token { get; set; } = String.Empty;

        [Column("password")]
        public string Password { get; set; } = String.Empty;  // PasswordHash

        public User(string email, string password, string rolename) 
        {
            Email = email;
            Password = password;
            Rolename = rolename;
        }
    }
}
