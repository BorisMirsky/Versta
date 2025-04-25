namespace Versta.API.Contracts
{
    public record OrdersSearchRequest
    (
        string? Search, string? SortItem, string? SortOrder
    );
}

