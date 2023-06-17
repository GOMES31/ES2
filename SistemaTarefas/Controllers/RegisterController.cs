using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SistemaTarefas.Context;
using SistemaTarefas.Entities;
using SistemaTarefas.Models;

namespace SistemaTarefas.Controllers;

public class RegisterController : Controller
{
    private readonly SistemaDbContext _context;

    public RegisterController()
    {
        _context = new SistemaDbContext();
    }

    public IActionResult Register()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register([Bind("Name,Email,Password")] RegisterModel register)
    {
        if(!ModelState.IsValid) return View();
        
        // Verificar se o email já está a ser usado por outro user
        // TODO - SUBSTITUIR ISTO PELA API
        var existingUser = _context.Users.FirstOrDefault(u => u.email.Equals(register.Email));
        if (existingUser != null)
        {
            ModelState.AddModelError("Email", "O email já está em uso.");
            return View(register);
        }

        // Criar um novo objeto de user com os dados do registo
        var newUser = new User
        {
            email = register.Email,
            password = register.Password,
            name = register.Name
        };

        // Guardar o novo utilizador na base de dados
        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();

        // Redirecionar para a página inicial
        return RedirectToAction("Index","Home");
    }

}  