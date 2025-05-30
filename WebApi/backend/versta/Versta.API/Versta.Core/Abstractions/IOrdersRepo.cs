using Versta.Core.Models;
//using Versta.DataAccess.Entities;
//using Microsoft.AspNetCore.Mvc;




namespace Versta.Core.Abstractions
{
    public interface IOrdersRepo
    {
        //  Task<IActionResult>    Task<List<Order>>
        Task<List<Order>> Get(); //string? Search, string? SortItem, string? SortOrder); //, string? SortOrder);    //
        Task<Order> Get(Guid id);
        Task<Guid> Create(Order order);
        Task<Guid> Update(Guid id, string cityFrom, string adressFrom,
            string cityTo, string adressTo, decimal weight,
            DateTime date, string specialNote);
        //Task<List<Order>> Delete(Guid id);
        Task<Guid> Delete(Guid id);
    }
}
