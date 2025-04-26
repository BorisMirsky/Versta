using Microsoft.EntityFrameworkCore;
using Versta.Core.Models;
using Versta.Core.Abstractions;
using Versta.DataAccess;
using Versta.DataAccess.Entities;
using Versta.Contracts.Contracts;
using System.Linq.Expressions;
using System.Linq;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;



namespace Versta.DataAccess.Repo
{
    public class OrdersRepo : IOrdersRepo
    {

        private readonly VerstaDbContext _context;

        public OrdersRepo(VerstaDbContext context)
        {
            _context = context;
        }

        //public async Task<List<Order>>    Task<IActionResult>
        public async Task<List<Order>> Get(string? Search, string? SortItem, string? SortOrder)
                                            //CancellationToken ct)  
                                           
        {
            var ordersQuery = _context.Orders
                    .Where(o => string.IsNullOrWhiteSpace(Search) ||
                            o.CityFrom.ToLower().Contains(Search.ToLower()) ||
                            o.CityTo.ToLower().Contains(Search.ToLower()));

            Expression<Func<Order, object>> selectorKey = SortItem?.ToLower() switch
            {
                "date" => order => order.Date,
                "cityto" => order => order.CityTo,
                "cityfrom" => order => order.CityFrom,
                _ => order => order.Id
            };

            //if (SortOrder == "desc")
            //{
            //    ordersQuery = ordersQuery.OrderByDescending(selectorKey);
            //}
            //else
            //{
            //    ordersQuery = ordersQuery.OrderBy(o => o.Date);
            //}

            //var noteDtos = await ordersQuery
            //    .Select(o => new OrderDto(o.Id, o.CityFrom, o.AdressFrom,
            //                                o.CityTo, o.AdressTo, o.Weight,
            //                                o.Date, o.SpecialNote))
            //    .ToListAsync(); // cancellationToken: ct);

            var orders = ordersQuery
                .Select(o => Order.Create(o.Id, o.CityFrom, o.AdressFrom,
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

        public async Task<List<Order>> Delete(Guid id)    
        {
            await _context.Orders
                .Where(o => o.Id == id)
                .ExecuteDeleteAsync();
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


//if (SortOrder == "desc")
//{
//    ordersQuery = ordersQuery.OrderByDescending<OrderEntity>(selectorKey);
//}
//else
//{
//    ordersQuery = ordersQuery.OrderBy(o => o.Date);
//}