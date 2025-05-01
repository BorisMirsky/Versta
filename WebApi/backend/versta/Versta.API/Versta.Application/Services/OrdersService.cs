using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Versta.DataAccess.Repo;
using Versta.Core.Models;
using Versta.Core.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Versta.Application.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepo _ordersRepo;
        public OrdersService(IOrdersRepo ordersRepo)
        {
            _ordersRepo = ordersRepo;
        }

        // Task<List<Order>>  Task<IActionResult>
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

        public void DeleteOrder(Guid id)
        //public async Task<List<Order>> DeleteOrder(Guid id)
        {
            //return await _ordersRepo.Delete(id);
            _ordersRepo.Delete(id);
        }
    }
}

//Сервисы соединяют БД с контроллреами:
//будет использовать репо, и например делать валидацию, кеширование, обращение к бд и т.д.
// эту логику лучше хранить тут а не в конроллерах
