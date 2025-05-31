

namespace Versta.Core.Models
{
    public class Role
    {
        public Role(string name)
        {
           Name = name;
        } 

        public int Id { get; set; }
        public string Name { get; set; } = "";
        //public Role()
        //{
        //    Users = new List<User>();
        //}
        public List<User> Users { get; set; } //= [];  // new List<User>();
    }
}
