﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using SistemaTarefas.Context;
using SistemaTarefas.Entities;

namespace SistemaTarefas.Controllers
{
    public class TarefasController : Controller
    {
        private readonly SistemaDbContext _context;

        public TarefasController()
        {
            _context = new SistemaDbContext();
        }

        
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tarefas.Include(x => x.projetos).OrderBy(m => m.id_tarefa).ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefa = await _context.Tarefas
                .Include(x => x.projetos)
                .FirstOrDefaultAsync(m => m.id_tarefa == id);
            if (tarefa == null)
            {
                return NotFound();
            }

            return View(tarefa);
        }

        public IActionResult Create()
        {
            ViewData["user"] = new SelectList(_context.Users, "idUser", "email");
            ViewData["projeto"] = new SelectList(_context.Projects, "idproject", "nomeProjeto");
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_utilizador,id_tarefa,hora_inicio,hora_fim,descricao,precohora,nomeProjeto")] Tarefa tarefa)
        {
            var errors2 = new List<string>();
            System.Diagnostics.Debug.WriteLine(tarefa.hora_inicio);
            if (tarefa.hora_fim < tarefa.hora_inicio)
            {
                errors2.Add("End date needs to be after start date");
            }

            tarefa.estado = "curso";
            tarefa.Username = UserSession.Username;
            if (ModelState.IsValid && errors2.Count <= 0)
            {
                _context.Add(tarefa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Errors2"] = errors2;
            return View(tarefa);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewData["estado"] = new SelectList(new List<string>(){"curso", "finalizado"});
            ViewData["user"] = new SelectList(_context.Users, "idUser", "email");
            ViewData["projeto"] = new SelectList(_context.Projects, "idproject", "nomeProjeto");
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa == null)
            {
                return NotFound();
            }
            return View(tarefa);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_tarefa,id_projeto,id_utilizador,hora_inicio,hora_fim,estado,descricao,precohora")] Tarefa tarefa)
        {

            if (id != tarefa.id_tarefa)
            {
                return NotFound();
            }
            ViewData["estado"] = new SelectList(new List<string>(){"curso", "finalizado"});
            var errors = new List<string>();
            if (tarefa.hora_fim < tarefa.hora_inicio)
            {
                errors.Add("a data final nao pode ser menor que a data inicial");
            }

            if (ModelState.IsValid && errors.Count <= 0)
            {
                _context.Update(tarefa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Errors"] = errors;
            return View(tarefa);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefa = await _context.Tarefas
                // .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.id_tarefa == id);
            if (tarefa == null)
            {
                return NotFound();
            }

            return View(tarefa);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MealExists(int id)
        {
            return _context.Projects.Any(e => e.idproject == id);
        }
    }
}