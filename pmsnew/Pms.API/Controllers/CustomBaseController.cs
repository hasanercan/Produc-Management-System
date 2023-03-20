using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pms.Core;
using Pms.Core.Dtos;
using Pms.Core.Services;

namespace Pms.API.Controllers;


public class CustomBaseController : ControllerBase
{
    [NonAction]
    public IActionResult CreateActionResult<T>(CustomResponseDto<T> response)
    {
        if (response.StatusCode == 204)
            return new ObjectResult(null)
            {
                StatusCode = response.StatusCode
            };
        return new ObjectResult(response)
        {
            StatusCode = response.StatusCode
        };
    }

}

