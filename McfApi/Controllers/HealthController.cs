using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace McfApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        // Endpoint Check Health
        [HttpGet("[action]")]
        public IActionResult GetHealth()
        {
            return Ok("Get Health");
        }
    }
}
