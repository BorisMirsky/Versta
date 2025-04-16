namespace Versta.API.Contracts
{
    public record OrdersResponse
        (
        Guid Id,
        string CityFrom,
        string AdressFrom,
        string CityTo,
        string AdressTo,
        decimal Weight,
        DateTime Date,
        string SpecialNote
        );
}
