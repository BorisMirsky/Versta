using Versta.Core.Models;
//using Versta.DataAccess.Entities;


namespace Versta.Core.Abstractions
{
    public interface IOrdersRepo
    {
        Task<List<Order>> Get();
        Task<Order> Get(Guid id);
        Task<Guid> Create(Order order);
        Task<Guid> Update(Guid id, string cityFrom, string adressFrom,
            string cityTo, string adressTo, decimal weight,
            DateTime date, string specialNote);
        Task<Guid> Delete(Guid id);
    }
}
