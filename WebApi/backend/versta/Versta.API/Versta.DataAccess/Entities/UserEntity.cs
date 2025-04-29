using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Versta.DataAccess.Entities
{
    [Table("users")]
    public class UserEntity
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("username")]
        public string UserName { get; set; } = "";

        //[Column("name")]
        //public string Name { get; set; } = "";

        [Column("role")]
        public string Role { get; set; } = "";   //Everyone

        [Column("isactive")]
        public bool IsActive { get; set; } = false;

        [Column("token")]
        public string Token { get; set; } = "";

        [Column("password")]
        public string Password { get; set; } = "";
    }
}
