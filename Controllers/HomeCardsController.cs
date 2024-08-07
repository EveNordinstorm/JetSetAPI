using JetSetAPI.Models;
using JetSetAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace JetSetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeCardsController : ControllerBase
    {
        private readonly JsonFileService _jsonFileService;

        public HomeCardsController(JsonFileService jsonFileService)
        {
            _jsonFileService = jsonFileService;
        }

        [HttpGet]
        public IEnumerable<HomeCard> Get()
        {
            return _jsonFileService.GetItems<HomeCard>("HomeCards.json");
        }
    }
}