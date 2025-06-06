﻿namespace Versta.API.Contracts
{
    public record OrdersRequest
    (
        string CityFrom,
        string AdressFrom,
        string CityTo,
        string AdressTo,
        decimal Weight,
        DateTime Date,
        string SpecialNote
    );
}
