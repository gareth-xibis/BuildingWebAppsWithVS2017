using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpyStore.DAL.Repos.Interfaces;
using SpyStore.Models.ViewModels.Base;
using SpyStore.Models.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpyStore.Service.Controllers
{
    [Route("api/[controller]/{customerId}")]
    public class OrderController : Controller
    {
        private IOrderRepo Repo { get; set; }

        public OrderController(IOrderRepo repo)
        {
            Repo = repo;
        }

        public IActionResult GetOrderHistory(int customerId)
        {
            var orderWithTotals = Repo.GetOrderHistory(customerId);
            return orderWithTotals == null ? (IActionResult) NotFound() : new ObjectResult(orderWithTotals);
        }

        [HttpGet("{orderId}", Name = "GetOrderDetails")]
        public IActionResult GetOrderForCustomer(int customerId, int orderId)
        {
            var orderWithDetails = Repo.GetOneWithDetails(customerId, orderId);
            return orderWithDetails == null ? (IActionResult) NotFound() : new ObjectResult(orderWithDetails);
        }

    }
}
