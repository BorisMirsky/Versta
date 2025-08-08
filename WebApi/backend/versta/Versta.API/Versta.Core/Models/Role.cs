

using System.ComponentModel.DataAnnotations.Schema;

namespace Versta.Core.Models
{
    [Table("Roles")]
    public class Role
    {
        public Role(string name)
        {
           Name = name;
        } 

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        //public List<User>? Users { get; set; } 
    }
}


