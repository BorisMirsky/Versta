namespace Versta.API.Contracts
{
    public record LoginRequest
    {
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
    }
}
