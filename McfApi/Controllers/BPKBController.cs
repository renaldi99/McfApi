using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using McfApi.DTOs;
using McfApi.Exceptions;
using McfApi.Models;
using McfApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace McfApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BPKBController : ControllerBase
    {
        private readonly IBPKBService _service;

        public BPKBController(IBPKBService service)
        {
            _service = service;
        }

        // Insert Form BPKB
        [HttpPost("[action]")]
        public async Task<IActionResult> InsertDataBpkb([FromBody] BPKBDto bPKBDto)
        {
            if (!ModelState.IsValid)
            {
                throw new BadRequestException("Bad Request Data");
            }

            var result = await _service.CreateDataBpkb(bPKBDto);
            if (result == 0)
            {
                throw new Exception("Internal Data Error");
            }

            return Ok(new PayloadDetails { is_success = true, status_code = StatusCodes.Status200OK, message = "Success Create Bpkb" });
        }

        // Insert Form BPKB
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateDataBpkb([FromBody] BPKBDto bPKBDto)
        {
            if (!ModelState.IsValid)
            {
                throw new BadRequestException("Bad Request Data");
            }

            var result = await _service.UpdateDataBpkb(bPKBDto);
            if (result == 0)
            {
                throw new Exception("Internal Data Error");
            }

            return Ok(new PayloadDetails { is_success = true, status_code = StatusCodes.Status200OK, message = "Success Update Bpkb" });
        }

        // Get List BPKB
        [HttpPost("[action]")]
        public async Task<IActionResult> ListDataBpkb()
        {
            var result = await _service.GetListBpkb();

            return Ok(new ResponseData { is_success = true, status_code = StatusCodes.Status200OK, message = "Success Get List Bpkb", data = result });
        }

        // Get List BPKB
        [HttpPost("[action]")]
        public async Task<IActionResult> GetDataBpkbByAgreementNumber([FromQuery] int agreement_number)
        {
            var result = await _service.GetBpkbByAgreementNumber(agreement_number);

            return Ok(new ResponseData { is_success = true, status_code = StatusCodes.Status200OK, message = "Success Get Bpkb", data = result });
        }
    }
}
