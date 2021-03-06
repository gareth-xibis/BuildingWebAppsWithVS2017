﻿using System;
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
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private ICustomerRepo Repo { get; set; }

        public CustomerController(ICustomerRepo repo)
        {
            Repo = repo;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Customer> Get() => Repo.GetAll();
        

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = Repo.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            return new ObjectResult(item);
        }
    }
}
