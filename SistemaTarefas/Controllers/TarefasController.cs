using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Exceptions;
using Microsoft.Build.Framework;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
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
            var user = UserSession.Username;

            var tasks = await _context.Tarefas
                .Where(t => t.Username == user)
                .OrderBy(m => m.id_tarefa)
                .ToListAsync();

            return View(tasks);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = UserSession.Username;

            var tarefa = await _context.Tarefas
                .FirstOrDefaultAsync(m => m.id_tarefa == id && m.Username == user);
    
            if (tarefa == null)
            {
                return NotFound();
            }

            return View(tarefa);
        }

        public IActionResult Create()
        {
            ViewData["user"] = new SelectList(_context.Users, "idUser", "email");
            var username = UserSession.Username;
            
            ViewBag.projetos = new SelectList(_context.Projects.Where(p => p.Username == username), "idproject", "nomeProjeto");
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_utilizador,id_tarefa,hora_inicio,hora_fim,descricao,precohora,id_projeto,nome_projeto")] Tarefa tarefa)
        {
            var errors2 = new List<string>();
            System.Diagnostics.Debug.WriteLine(tarefa.hora_inicio);
            if (tarefa.hora_fim < tarefa.hora_inicio)
            {
                errors2.Add("Data final tem que ser posterior à inicial!");
            }

            tarefa.estado = "curso";
            tarefa.Username = UserSession.Username;
            if (ModelState.IsValid && errors2.Count <= 0)
            {
                var projectName = _context.GetProjectNameById(tarefa.id_projeto);
                tarefa.nome_projeto = projectName;
                
                var selectedProject = await _context.Projects.Include(p => p.tarefas).FirstOrDefaultAsync(p => p.idproject == tarefa.id_projeto);
                if (selectedProject != null)
                {
                    selectedProject.tarefas.Add(tarefa);
                    selectedProject.precohora += tarefa.precohora;

                    _context.Update(selectedProject);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
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
            ViewBag.estado = new SelectList(new List<string>(){"curso", "finalizado"});

            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa == null)
            {
                return NotFound();
            }
            
            tarefa.Username = UserSession.Username;
            return View(tarefa);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_tarefa,estado,hora_inicio,hora_fim,descricao,precohora")] Tarefa tarefa)
        {

            if (id != tarefa.id_tarefa)
            {
                return NotFound();
            }
            var errors = new List<string>();
            if (tarefa.hora_fim < tarefa.hora_inicio)
            {
                errors.Add("a data final nao pode ser menor que a data inicial");
            }
            
            ViewBag.estado = new SelectList(new List<string>(){"curso", "finalizado"});
            
            if (ModelState.IsValid && errors.Count <= 0)
            {
                var existingTask = await _context.Tarefas.FindAsync(id);
                if (existingTask == null)
                {
                    return NotFound();
                }
                
                existingTask.hora_fim = tarefa.hora_fim;
                existingTask.descricao = tarefa.descricao;
                existingTask.precohora = tarefa.precohora;
                existingTask.estado = Request.Form["estado"];

                _context.Update(existingTask);
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

            if (tarefa.id_projeto.HasValue)
            {
                var projeto = await _context.Projects.FindAsync(tarefa.id_projeto.Value);

                if (projeto != null)
                {
                    projeto.precohora -= tarefa.precohora;
                    _context.Update(projeto);
                }
            }
            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
    }
}