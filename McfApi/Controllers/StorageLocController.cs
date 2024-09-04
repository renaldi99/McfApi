using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using McfApi.DTOs;
using McfApi.Models;
using McfApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace McfApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StorageLocController : ControllerBase
    {
        private readonly IStorageLocService _service;

        public StorageLocController(IStorageLocService service)
        {
            _service = service;
        }

        // Insert New Location
        [HttpPost("[action]")]
        public async Task<IActionResult> InsertLocation([FromBody] StorageLocDto storageLocDto)
        {
            var result = await _service.CreateLocation(storageLocDto);

            return Ok(new PayloadDetails { is_success = true, status_code = StatusCodes.Status200OK, message = "Success Create Location" });
        }

        // Update Location
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateLocation([FromBody] StorageLocDto storageLocDto)
        {
            var result = await _service.UpdateLocation(storageLocDto);

            return Ok(new PayloadDetails { is_success = true, status_code = StatusCodes.Status200OK, message = "Success Update Location" });
        }

        // For Value Dropdown Location
        [HttpPost("[action]")]
        public async Task<IActionResult> GetListLocation()
        {
            var result = await _service.GetListLocation();

            return Ok(new ResponseData { is_success = true, status_code = StatusCodes.Status200OK, message = "Success Get List Location", data = result });
        }
    }
}
