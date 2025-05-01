using Versta.Core.Abstractions;
using Versta.Core.Models;
//using Versta.API.Contracts;
using Versta.Contracts.Contracts;
//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using System;



namespace Versta.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;
        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }


        [HttpGet]
        public async Task<ActionResult<List<OrdersResponse>>> GetAllOrders([FromQuery] OrdersSearchRequest request)
        {
            var orders = await _ordersService.GetAllOrders(request?.Search, 
                                                           request?.SortItem,
                                                           request?.SortOrder);
            var responce = orders.Select(o => new OrdersResponse(o.Id, o.CityFrom,
                o.AdressFrom, o.CityTo, o.AdressTo,
                o.Weight, o.Date, o.SpecialNote));
            return Ok(responce);
        }


        [HttpGet("{id}")]   
        public async Task<ActionResult<OrdersResponse>> GetOneOrder(Guid id)  
        {
            var order = await _ordersService.GetOneOrder(id);
            return Ok(order);
        }
         

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateOrder([FromBody] OrdersRequest request)
        {
            var (order, error) = Order.Create(
                Guid.NewGuid(),
                request.CityFrom,
                request.AdressFrom,
                request.CityTo,
                request.AdressTo,
                request.Weight,
                request.Date,
                request.SpecialNote                               
                );

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }
            var newOrder = await _ordersService.CreateOrder(order);
            return Ok(newOrder);
        }


        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateOrder(Guid id, [FromBody] OrdersRequest request)
        {
            var orderId = await _ordersService.UpdateOrder(id, 
                request.CityFrom, request.AdressFrom, 
                request.CityTo, request.AdressTo, 
                request.Weight, request.Date, request.SpecialNote);
            return Ok(orderId);
        }


        [HttpDelete("{id:guid}")]
        public void DeleteOrder(Guid id)
        //public async Task<ActionResult<List<OrdersResponse>>> DeleteOrder(Guid id)
        {
            //return Ok(await _ordersService.DeleteOrder(id));
            _ordersService.DeleteOrder(id);
        }
    }
}
