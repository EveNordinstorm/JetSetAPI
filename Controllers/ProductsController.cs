using JetSetAPI.Models;
using JetSetAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace JetSetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly JsonFileService _jsonFileService;

        public ProductsController(JsonFileService jsonFileService)
        {
            _jsonFileService = jsonFileService;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _jsonFileService.GetItems<Product>("Products.json");
        }
    }
}