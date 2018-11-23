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
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private IProductRepo Repo { get; set; }

        public SearchController(IProductRepo repo)
        {
            Repo = repo;
        }

        // GET: api/<controller>
        [HttpGet("{searchString}", Name = "SearchProducts")]
        public IEnumerable<ProductAndCategoryBase> Search(string searchString) => Repo.Search(searchString);

    }
}
