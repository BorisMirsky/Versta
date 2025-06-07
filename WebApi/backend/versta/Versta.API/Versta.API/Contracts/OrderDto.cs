
namespace Versta.Contracts.Contracts
{
    public record OrderDto(
        Guid Id,
        string CityFrom,
        string AdressFrom,
        string CityTo,
        string AdressTo,
        decimal Weight,
        DateTime Date,
        string? SpecialNote
    );
}

