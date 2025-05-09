namespace Versta.API.Contracts
{
    public record LoginRequest
    {
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
    }
}
