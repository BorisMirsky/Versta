using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Versta.Models;
using Versta.Entities;
using Microsoft.EntityFrameworkCore;
using System;



namespace Versta.Controllers
{
    public class HomeController : Controller
    {

        private OrderContext db;

        public HomeController(OrderContext context)
        {
            db = context;
        }


        private OrderModel GetModel(IEnumerable<OrderInfo> orders) => new OrderModel
        {
            Orders = orders
        };


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(GetModel(await db.OrdersDB.ToListAsync()));
        }


        //public IActionResult Index1()
        //{
        //    return View();
        //}

        [HttpGet]
        public IActionResult CreateNewOrder() 
        {
            CreateNewOrderModel model = new CreateNewOrderModel();
            return View(model);
        }


        [HttpPost]
        public async Task<ActionResult> CreateNewOrder(CreateNewOrderModel model)
        {
            string guid = Guid.NewGuid().ToString();
            if (ModelState.IsValid)
            {
                db.OrdersDB.Add(new OrderInfo()
                {
                    unique_id = guid,
                    city_from = model.CityFrom,
                    address_from = model.AdressFrom,
                    city_to = model.CityTo,
                    address_to = model.AdressTo,
                    weight = model.Weight,
                    date = model.Date
                });
                await db.SaveChangesAsync();
                // userInfo чтобы вынуть id для redirect
                OrderInfo orderInfo = (from ord in db.OrdersDB
                                       where ord.unique_id == guid
                                       select ord).SingleOrDefault();
                return RedirectToAction("OrderPage", new { orderInfo?.id });
            }
            else
            {
                return View(model);
            }
        }


        public IActionResult OrderPage(int? id)
        {
            OrderInfo? orderInfo = (from ord in db.OrdersDB
                                  where ord.id == id
                                  select ord).SingleOrDefault();
            OrderModel order = new OrderModel();
            order.Order = orderInfo!;
            //Debug.WriteLine("orderInfo from OrderPage: ", order?.ToString());
            return View(order);
        }


        [HttpGet]
        public IActionResult EditOrderPage(int id)  
        {
            OrderInfo? orderInfo = (from ord in db.OrdersDB
                                    where ord.id == id
                                    select ord).SingleOrDefault();
            OrderModel model = new OrderModel();
            model.Order = orderInfo!;
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> EditOrder(int id, OrderModel model)
        {
            OrderInfo? orderInfo = (from ord in db.OrdersDB
                                     where ord.id == id
                                     select ord).SingleOrDefault();
            if (ModelState.IsValid)
            {
                orderInfo.city_from = model.Order.city_from;
                orderInfo.address_from = model.Order.address_from;
                orderInfo.city_to = model.Order.city_to;
                orderInfo.address_to = model.Order.address_to;
                orderInfo.weight = model.Order.weight;
                orderInfo.date = model.Order.date;
                db.OrdersDB.Update(orderInfo);
                await db.SaveChangesAsync();
                return RedirectToAction("OrderPage", new { id });
            }
            else
            {
                return View("Not Found");
            }
        }


        [HttpGet]
        public async Task<IActionResult> DeleteOrderPage(int? id)
        {
            if (ModelState.IsValid) 
            {
                OrderInfo? orderInfo = (from ord in db.OrdersDB
                                        where ord.id == id
                                        select ord).SingleOrDefault();
                OrderModel order = new OrderModel();
                order.Order = orderInfo!;
                db.OrdersDB.Remove(orderInfo!);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}