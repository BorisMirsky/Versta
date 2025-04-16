using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Versta.DataAccess.Repo;
using Versta.Core.Models;
using Versta.Core.Abstractions;


namespace Versta.Application.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepo _ordersRepo;
        public OrdersService(IOrdersRepo ordersRepo)
        {
            _ordersRepo = ordersRepo;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await _ordersRepo.Get();
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
            return await _ordersRepo.Delete(id);
        }
    }
}

//Сервисы соединяют БД с контроллреами:
//будет использовать репо, и например делать валидацию, кеширование, обращение к бд и т.д.
// эту логику лучше хранить тут а не в конроллерах
