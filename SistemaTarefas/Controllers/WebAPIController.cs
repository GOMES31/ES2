using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using SistemaTarefas.Context;

namespace SistemaTarefas.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class WebAPIController : ControllerBase
    {
        private readonly SistemaDbContext _context;

        public WebAPIController(SistemaDbContext context)
        {
            _context = context;
        }

        [HttpGet("userEmails")]
        public IActionResult GetUserEmails()
        {
            List<string> userEmails = _context.Users.Select(u => u.email).ToList();
            return Ok(userEmails);
        }
    }
}