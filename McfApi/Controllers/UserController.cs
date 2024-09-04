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
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        // Insert New User
        [HttpPost("[action]")]
        public async Task<IActionResult> InsertNewUser([FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                throw new BadRequestException("Bad Request Data");
            }

            var result = await _service.CreateUser(userDto);
            if (result == 0)
            {
                throw new Exception("Internal Data Error");
            }

            return Ok(new PayloadDetails { is_success = true, status_code = StatusCodes.Status200OK, message = "Success Create User" });
        }

        // Process Login User
        [HttpPost("[action]")]
        public async Task<IActionResult> LoginUser([FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                throw new BadRequestException("Bad Request Data");
            }

            var result = await _service.ProcessLoginUser(userDto.user_name, userDto.password);
            if (result == null)
            {
                throw new Exception("Internal Data Error");
            }

            return Ok(new ResponseData { is_success = true, status_code = StatusCodes.Status200OK, message = "Login Success", data = result });
        }
    }
}
