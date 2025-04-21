using Versta.Core.Models;


namespace Versta.Core.Abstractions
{
    public interface IOrdersService
    {
        Task<List<Order>> GetAllOrders();
        Task<Order> GetOneOrder(Guid id);
        Task<Guid> CreateOrder(Order order);
        Task<Guid> UpdateOrder(Guid id, string cityFrom, string adressFrom,
            string cityTo, string adressTo, decimal weight,
            DateTime date, string specialNote);
        //Task<Guid> DeleteOrder(Guid id);
        Task<List<Order>> DeleteOrder(Guid id);
    }
}
