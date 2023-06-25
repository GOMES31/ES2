using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SistemaTarefas.Context;
using SistemaTarefas.Entities;
using SistemaTarefas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SistemaTarefas.Controllers
{
    public partial class L_TarefasFinalizadasController : Controller
    {
        private readonly SistemaDbContext _context;

        public L_TarefasFinalizadasController()
        {
            _context = new SistemaDbContext();
        }

        public async Task<IActionResult> Index()
        {
            var user = UserSession.Username;

            var tasks = await _context.Tarefas
                .Where(t => t.Username == user && t.estado == "finalizado")
                .OrderBy(m => m.id_tarefa)
                .ToListAsync();

            return View(tasks);
        }
    }
}