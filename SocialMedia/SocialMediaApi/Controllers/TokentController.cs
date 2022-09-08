using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using SocialMedia_Core.Entities;
using System;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SocialMediaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokentController : ControllerBase
    {
        private readonly IConfiguration _configuration; 
        public TokentController(IConfiguration configuration)
        {
            _configuration = configuration; 
        }
        [HttpPost]
        public IActionResult Authentication(UserLogin login)
        {
            //if it is a valid user
            if (IsvalidUser())
            {
                var token = GenerateToken();
                return Ok(new { token });
            }
            return NotFound();
        }

        public bool IsvalidUser()
        {
            return true;
        }
        private string GenerateToken()
        {
            //Primero generamos el header
            var symetricSegurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:Secretkey"]));
            var singingCredentials = new SigningCredentials (symetricSegurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(singingCredentials);

            //Clains
            var clains = new[]
            {
                new Claim(ClaimTypes.Name, "agustin gomez"),
                new Claim(ClaimTypes.Email, "agustingomez@gmail.com"),
                new Claim(ClaimTypes.Role, "Administrador"),
            };

            //playload
            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
               clains,
               DateTime.Now,
               DateTime.UtcNow.AddMinutes(5)
            );

            var token = new JwtSecurityToken(header, payload);


            return new JwtSecurityTokenHandler().WriteToken(token);


        }
    }
}
