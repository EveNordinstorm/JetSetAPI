using JetSetAPI.Models;
using JetSetAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace JetSetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidaysController : ControllerBase
    {
        private readonly JsonFileService _jsonFileService;

        public HolidaysController(JsonFileService jsonFileService)
        {
            _jsonFileService = jsonFileService;
        }

        [HttpGet]
        public IEnumerable<Holiday> Get()
        {
            return _jsonFileService.GetItems<Holiday>("Holidays.json");
        }
    }
}