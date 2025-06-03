

namespace Versta.Core.Models
{
    public class Role
    {
        public Role(string name)
        {
           Name = name;
        } 

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<User>? Users { get; set; } 
    }
}


