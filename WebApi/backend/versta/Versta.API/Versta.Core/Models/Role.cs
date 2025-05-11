

namespace Versta.Core.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Role(string name) => Name = name;
    }
}
