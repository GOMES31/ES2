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
            //var tarefas = await _context.Tarefas.Where(m => m.id_projeto == meal.idproject).ToListAsync();
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
        public async Task<IActionResult> Create([Bind("nomeProjeto,precohora,nomecliente")] Projeto projeto)
        {
            if (ModelState.IsValid)
            {
                projeto.Username = UserSession.Username;
                
                Debug.Write(projeto.idproject);
                _context.Add(projeto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projeto);
        }
        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
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
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idproject,nomeProjeto,precohora,nomecliente")] Projeto projeto)
        {
            if (id != projeto.idproject)
            {
                return NotFound();
            }

            var errors = new List<string>();

            if (projeto.precohora is < 0)
            {
                errors.Add("The price can't be negative");
            }

            if (ModelState.IsValid && errors.Count <= 0)
            {

                projeto.nomeProjeto = projeto.nomeProjeto;
                projeto.nomeProjeto = projeto.nomeProjeto;
                projeto.precohora = projeto.precohora;
                projeto.nomecliente = projeto.nomecliente;
                
                _context.Update(projeto);

                // Save the changes
                await _context.SaveChangesAsync();

                // Reload the updated project from the context
                await _context.Entry(projeto).ReloadAsync();

                return View(projeto);
            }
            ViewData["Errors"] = errors;
            return View(projeto);
        }

        // GET: Meal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meal = await _context.Projects.FirstOrDefaultAsync(m => m.idproject == id);
            if (meal == null)
            {
                return NotFound();
            }

            return View(meal);
        }

        // POST: Meal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meal = await _context.Projects.FindAsync(id);
            var tarefas = await _context.Tarefas.Where(m => m.id_projeto == meal.idproject).ToListAsync();
            if (meal != null)
            {
                foreach (var tarefa in tarefas)
                {
                    tarefa.projetos = null;
                    tarefa.id_projeto = null;
                    _context.Tarefas.Update(tarefa);
                }
                _context.Projects.Remove(meal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DeleteALL(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meal = await _context.Projects.FirstOrDefaultAsync(m => m.idproject == id);
            if (meal == null)
            {
                return NotFound();
            }

            return View(meal);
        }
        // POST: Meal/Delete/5
        [HttpPost, ActionName("DeleteALL")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProjTarefas(int id)
        {
            var meal = await _context.Projects.FindAsync(id);
            var tarefas = await _context.Tarefas.Where(m => m.id_projeto == meal.idproject).ToListAsync();
            if (meal != null)
            {
                foreach (var tarefa in tarefas)
                {
                    _context.Tarefas.Remove(tarefa);
                }
                _context.Projects.Remove(meal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MealExists(int id)
        {
            return _context.Projects.Any(e => e.idproject == id);
        }
    }
}
