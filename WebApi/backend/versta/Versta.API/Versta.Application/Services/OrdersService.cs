using Versta.Core.Models;
using Versta.Core.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Versta.Application.Services
{
    public class OrdersService(IOrdersRepo ordersRepo) : IOrdersService
    {
        
        private readonly IOrdersRepo _ordersRepo = ordersRepo;

        public async Task<List<Order>> GetAllOrders(string? Search, string? SortItem, string? SortOrder)
        {
            return await _ordersRepo.Get(Search, SortItem, SortOrder);
        }

        public async Task<Order> GetOneOrder(Guid id)
        {
            return await _ordersRepo.Get(id);
        }

        public async Task<Guid> CreateOrder(Order order)
        {
            return await _ordersRepo.Create(order);
        }

        public async Task<Guid> UpdateOrder(Guid id, string cityFrom, string adressFrom,
            string cityTo, string adressTo, decimal weight, DateTime date, string specialNote)
        {
            return await _ordersRepo.Update(id, cityFrom, adressFrom,
                                            cityTo, adressTo, weight,
                                            date, specialNote);
        }

        public async Task<Guid> DeleteOrder(Guid id)
        {
            await _ordersRepo.Delete(id);
            return id;
        }
    }
}
