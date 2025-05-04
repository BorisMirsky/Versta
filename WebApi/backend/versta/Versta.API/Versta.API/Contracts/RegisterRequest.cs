namespace Versta.API.Contracts
{
    public class RegisterRequest
    {
        //public Guid Id { get; set; } = Guid.Empty;  //    NewGuid();
        //public string Name { get; set; } = "";
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
        //public string Role { get; set; } = "Everyone";
    }
}
