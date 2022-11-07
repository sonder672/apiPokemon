using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace pantera.controller.Controllers
{
    public class PokemonController : ControllerBase
    {
        [Route("api/token")]
        [HttpGet]
        [Authorize]
        public IActionResult validationToken()
        {
            return StatusCode(200, new { message = "Verified" });
        }
    }
}