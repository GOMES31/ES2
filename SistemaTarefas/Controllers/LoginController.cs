using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SistemaTarefas.Context;
using SistemaTarefas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SistemaTarefas.Controllers
{
    public class LoginController : Controller
    {
        private readonly SistemaDbContext _context;

        public LoginController()
        {
            _context = new SistemaDbContext();
        }
        
        public IActionResult Login()
        {
            return View();
        }  
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public Task<IActionResult> Login([Bind("Email,Password")] LoginModel login)
        {
            // var passHash = $"\\x{ComputeSha256Hash(login.Password)}";

            var user = _context.Users
                .FirstOrDefault(u => u.email.Equals(login.Email) && u.password.Equals(login.Password));

            if (user != null)
            {
                UserSession.UserId = user.idUser;
                UserSession.Username = user.name;
                return Task.FromResult<IActionResult>(RedirectToAction(controllerName: "Home", actionName: "Index"));
            }
            
            ViewData["HasError"] = true;
            
            return Task.FromResult<IActionResult>(RedirectToAction("Home"));
        }
        
        public IActionResult Home()
        {
            return RedirectToAction(controllerName: "Home", actionName: "Index");
        }
        
        public IActionResult Logout()
        {
            UserSession.UserId = null;
                UserSession.Username = null;
                return RedirectToAction(controllerName: "Home", actionName: "Index");
        }
        
        public IActionResult AlterarDados()
        {
            return (null);
        }
        
    }
}