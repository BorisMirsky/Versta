using Versta.Core.Models;


namespace Versta.Core.Abstractions
{
    public interface IOrdersService
    {
        Task<List<Order>> GetAllOrders(string? Search, string? SortItem, string? SortOrder); //, string? SortOrder);   
        Task<Order> GetOneOrder(Guid id);
        Task<Guid> CreateOrder(Order order);
        Task<Guid> UpdateOrder(Guid id, string cityFrom, string adressFrom,
            string cityTo, string adressTo, decimal weight,
            DateTime date, string specialNote);
        Task<Guid> DeleteOrder(Guid id);
    }
}
