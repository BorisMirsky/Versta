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
        public Guid? Id { get; set; }             // = Guid.Empty;
        public string? UserName { get; set; } = "";
        //public string? Name { get; set; } = "";
        public string? Role { get; set; } = "";   //Everyone
        public bool? IsActive { get; set; } = false;
        public string? Token { get; set; } = "";
        public string? Password { get; set; } = "";

        public User(string userName, string password) //string name, string password, string role)  //Guid id,
        {
            //Id = id;
            UserName = userName;
            //Name = name;
            Password = password;
            //Role = role;
        }
    }
    public class LoginUser
    {
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
    }

    public class RegisterUser
    {
        //public Guid Id { get; set; } = Guid.Empty;  //    NewGuid();
        //public string Name { get; set; } = "";
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
        //public string Role { get; set; } = "Everyone";
    }
}
