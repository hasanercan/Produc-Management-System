using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Pms.Core;
using Pms.Core.Dtos;
using Pms.Core.Services;

namespace Pms.API.Controllers;


[ApiController]
[Route("api/token")]

public class TokenController : CustomBaseController
{
    private readonly IMapper _mapper;
    private readonly ICategoryService _service;
    public IConfiguration _configuration;

    public TokenController(IConfiguration config, IMapper mapper, ICategoryService service)
    {
        _configuration = config;
        _mapper = mapper;
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Post(UserDto _userData)
    {
        var a = "admin";
        var b = "admin123";
        if (_userData != null && _userData.UserName != null && _userData.Password != null)
        {

            if (_userData.UserName.Equals(a) && _userData.Password.Equals(b))
            {
                //create claims details based on the user information
                var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserName", _userData.UserName),
        
                    };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: signIn);

                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }
            else
            {
                return BadRequest("Invalid credentials");
            }
        }
        else
        {
            return BadRequest();
        }
    }

  

}

