using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using online_store.Core.DTOs;
using online_store.Core.Interfaces;
using online_store_api.Helpers;
using System;

namespace online_store_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository repository;
        private readonly IConfiguration configuration;

        public UserController(IUserRepository repository, IConfiguration configuration)
        {
            this.repository = repository;
            this.configuration = configuration;
        }

        [HttpPost("login")]
        public ActionResult<UserResponseDTO> Login(UserDTO userDTO)
        {
            try
            {
                var userlogged = repository.GetUserByUsernameAndPassword(userDTO.Username, userDTO.Password);

                string secret = configuration["secretjwt"];
                var jwt = new JWTHelper(secret);
                var token = jwt.CreateToken(userDTO.Username);

                return Ok(new UserResponseDTO { Ok = true, Token = token });
            }
            catch (Exception e)
            {
                return BadRequest("User not exist");
            }
        }
    }
}
