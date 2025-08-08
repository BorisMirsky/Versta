using Microsoft.EntityFrameworkCore;
using Versta.Core.Models;
using Versta.Core.Abstractions;
using System.Linq.Expressions;
using System.Diagnostics;



namespace Versta.DataAccess.Repo
{
    public class OrdersRepo(VerstaDbContext context) : IOrdersRepo
    {

        private readonly VerstaDbContext _context = context;

        public async Task<List<Order>> Get(string? Search, string? SortItem, string? SortOrder)                                      
        {
            var ordersQuery = _context.Orders
                    .Where(o => string.IsNullOrWhiteSpace(Search) ||
                            o.CityFrom.ToLower().Contains(Search.ToLower())); 

            Expression<Func<Order, object>> selectorKey = SortItem?.ToLower() switch
            {
                "date" => order => order.Date,
                "cityfrom" => order => order.CityFrom,
                _ => order => order.Id
            };

            if (SortOrder == "desc")
            {
                ordersQuery = ordersQuery.OrderByDescending(selectorKey);
            }
            else
            {
                ordersQuery = ordersQuery.OrderBy(selectorKey);
            }

            var orders = await ordersQuery.Select(o => Order.Create(o.Id, o.CityFrom,
                                                o.AdressFrom, o.CityTo, o.AdressTo,
                                                o.Weight, o.Date, o.SpecialNote).order)
                                          .ToListAsync();

            return orders;
        }


        public async Task<Order> Get(Guid id) 
        {
            Order? ord = await _context.Orders
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(c => c.Id == id);
            return ord!;
        }


        public async Task<Guid> Create(Order order)
        {
            await _context.Orders.AddAsync(order); 
            await _context.SaveChangesAsync();
            return order.Id;   
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


        public async Task<Guid> Delete(Guid id)     
        {
            await _context.Orders
                    .Where(b => b.Id == id)
                    .ExecuteDeleteAsync();
            return id;
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