using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace SistemaTarefas.Controllers
{
    
    [Route("api/WebAPIController")]
    [ApiController]
    public class WebAPIController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("teste");
        }
    }
}