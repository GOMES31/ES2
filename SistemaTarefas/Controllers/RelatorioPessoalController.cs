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
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace SistemaTarefas.Controllers
{
    public partial class RelatorioPessoalController : Controller
    {
        private readonly SistemaDbContext _context;

        public RelatorioPessoalController()
        {
            _context = new SistemaDbContext();
        }

        public IActionResult Index()
        {
            List<Tarefa> tarefas = _context.SearchTarefas(DateTime.MinValue, DateTime.MaxValue).ToList();
            return View(tarefas);
        }

        [HttpPost]
        public IActionResult Index(int id,string data)
        {
            DateTime data2;
            data2 = DateTime.ParseExact(data,"yyyy-MM-dd",CultureInfo.InvariantCulture);
            
            List<Tarefa> tarefas = _context.SearchTarefasalinea11(data2,id).ToList();
            return View(tarefas);
        }
    }
}