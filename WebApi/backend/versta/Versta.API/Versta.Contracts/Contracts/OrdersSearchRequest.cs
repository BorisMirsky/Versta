namespace Versta.Contracts.Contracts
{
    public record OrdersSearchRequest
    (
        string? Search, string? SortItem, string? SortOrder
    );
}

