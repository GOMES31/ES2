using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DiaSymReader;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using SistemaTarefas.Context;
using SistemaTarefas.Entities;

namespace SistemaTarefas.Controllers
{
    public class ProjetosController : Controller
    {
        private readonly SistemaDbContext _context;

        public ProjetosController()
        {
            _context = new SistemaDbContext();
        }

        // GET: Meal
        public async Task<IActionResult> Index()
        {

            // Retrieve projects associated with the current user
            var userProjects = await _context.Projects
                .Where(p => p.Username == UserSession.Username)
                .OrderBy(m => m.nomecliente)
                .ToListAsync();

            return View(userProjects);
        }

        // GET: Meal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projeto = await _context.Projects.Include(x => x.tarefas).Where(y=>y.idproject == id).FirstOrDefaultAsync(m => m.idproject == id);
            if (projeto == null)
            {
                return NotFound();
            }

            return View(projeto);
        }
        
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("nomeProjeto,nomecliente")] Projeto projeto)
        {
            if (!ModelState.IsValid) return View(projeto);
            projeto.Username = UserSession.Username;
            projeto.tarefas = new List<Tarefa>();
            projeto.precohora = 0;    
            _context.Add(projeto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var projeto = await _context.Projects.FindAsync(id);
            if (projeto == null)
            {
                return NotFound();
            }

            return View(projeto);
        }
        
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idproject,nomeProjeto,nomecliente")] Projeto projeto)
        {
            if (id != projeto.idproject)
            {
                return NotFound();
            }

            var errors = new List<string>();

            if (ModelState.IsValid && errors.Count <= 0)
            {
                var existingProject = await _context.Projects.FindAsync(id);
                if (existingProject == null)
                {
                    return NotFound();
                }

                existingProject.precohora = projeto.precohora;
                existingProject.nomeProjeto = projeto.nomeProjeto;
                existingProject.nomecliente = projeto.nomecliente;

                existingProject.Username = UserSession.Username;
                _context.Update(existingProject);

                // Save the changes
                await _context.SaveChangesAsync();

                // Reload the updated project from the context
                await _context.Entry(projeto).ReloadAsync();

                return RedirectToAction("Index");
            }
            ViewData["Errors"] = errors;
            
            return View(projeto);
        }
        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projeto = await _context.Projects.FirstOrDefaultAsync(m => m.idproject == id);
            if (projeto == null)
            {
                return NotFound();
            }

            return View(projeto);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projeto = await _context.Projects.FindAsync(id);

            if (projeto != null)
            {
                var tarefas = await _context.Tarefas.Where(t => t.id_projeto == id).ToListAsync();

                foreach (var tarefa in tarefas)
                {
                    tarefa.id_projeto = null;
                    tarefa.nome_projeto = null;
                    projeto.tarefas.Remove(tarefa);
                    _context.Tarefas.Update(tarefa);
                }
                await _context.SaveChangesAsync();
                
                _context.Projects.Remove(projeto);

                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return NotFound();
        }
        public async Task<IActionResult> DeleteALL(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projeto = await _context.Projects.FirstOrDefaultAsync(m => m.idproject == id);
            if (projeto == null)
            {
                return NotFound();
            }

            return View(projeto);
        }
        
        
        [HttpPost, ActionName("DeleteALL")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProjTarefas(int id)
        {
            var projeto = await _context.Projects.FindAsync(id);
            var tarefas = await _context.Tarefas.Where(m => m.id_projeto == projeto.idproject).ToListAsync();

            if (projeto != null)
            {
                _context.Tarefas.RemoveRange(tarefas);

                await _context.SaveChangesAsync();
                
                _context.Projects.Remove(projeto);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return NotFound();
        }
    }
}
