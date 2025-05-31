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

        public static Role Roleentity { get; set; }

        [Column("rolename")]
        public string Rolename { get; set; } = Roleentity.Name;

        //[Column("roleid")]
        public int? RoleId { get; set; }

        [Column("isactive")]
        public bool? IsActive { get; set; } = false;

        [Column("token")]
        public string? Token { get; set; } = "";

        [Column("password")]
        public string? Password { get; set; } = "";   // PasswordHash



        public User(string email, string password, string rolename) 
        {
            Email = email;
            Password = password;
            Rolename = rolename;
        }
    }
}
