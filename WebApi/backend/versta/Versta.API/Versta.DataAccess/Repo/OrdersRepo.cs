using Microsoft.EntityFrameworkCore;
using Versta.Core.Models;
using Versta.Core.Abstractions;
using Versta.DataAccess;
using Versta.DataAccess.Entities;             



namespace Versta.DataAccess.Repo
{
    public class OrdersRepo : IOrdersRepo
    {
        private readonly VerstaDbContext _context;
        public OrdersRepo(VerstaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> Get()
        {
            var orderEntities = await _context.Orders
                .AsNoTracking()
                .ToListAsync();
            var orders = orderEntities
                .Select(o => Order.Create(o.Id, o.CityFrom,  o.AdressFrom, 
                                          o.CityTo, o.AdressTo, o.Weight, 
                                          o.Date, o.SpecialNote).order) 
                .ToList();

            return orders;
        }

        public async Task<Order> Get(Guid id) 
        {
            var orderEntities = await _context.Orders
                .AsNoTracking()
                .ToListAsync();
            var orderEntity = orderEntities
               .Where(item => item.Id == id)
               .ToList()
               .FirstOrDefault();
            var order = Order.Create(orderEntity!.Id, orderEntity.CityFrom,
                orderEntity.AdressFrom,
                orderEntity.CityTo, orderEntity.AdressTo, orderEntity.Weight,
                orderEntity.Date, orderEntity.SpecialNote).order;
            return order;
        }

        public async Task<Guid> Create(Order order)
        {
            var orderEntity = new OrderEntity
            {
                Id = order.Id,
                CityFrom = order.CityFrom,
                AdressFrom = order.AdressFrom,
                CityTo = order.CityTo,
                AdressTo = order.AdressTo,
                Weight = order.Weight,
                Date = order.Date,
                SpecialNote = order.SpecialNote
            };
            await _context.Orders.AddAsync(orderEntity);
            await _context.SaveChangesAsync();
            return orderEntity.Id;  
        }

        public async Task<Guid> Update(Guid id, string cityFrom, string adressFrom,
            string cityTo, string adressTo, decimal weight, DateTime date, string specialNote)
        {
            await _context.Orders
                .Where(o => o.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(o => o.CityFrom, o => cityFrom)
                    .SetProperty(o => o.AdressFrom, o => adressFrom)
                    .SetProperty(o => o.CityTo, o => cityTo)
                    .SetProperty(o => o.AdressTo, o => adressTo)
                    .SetProperty(o => o.Weight, o => weight)
                    .SetProperty(o => o.Date, o => date)
                    .SetProperty(o => o.SpecialNote, o => specialNote));
            return id;
        }

        //public async Task<Guid> Delete(Guid id)
        public async Task<List<Order>> Delete(Guid id)     //Task<Guid>
        {
            await _context.Orders
                .Where(o => o.Id == id)
                .ExecuteDeleteAsync();
            //return id;
            var orderEntities = await _context.Orders
                .AsNoTracking()
                .ToListAsync();
            var orders = orderEntities
                .Select(o => Order.Create(o.Id, o.CityFrom, o.AdressFrom,
                                          o.CityTo, o.AdressTo, o.Weight,
                                          o.Date, o.SpecialNote).order)
                .ToList();

            return orders;
        }
    }
}
