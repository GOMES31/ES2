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
using SistemaTarefas.Entities;

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
        public async Task<IActionResult> Login([Bind("Email,Password")] LoginModel login)
        {

            var users = await _context.Users.ToListAsync();
            
            
            // Check if the register.Email already exists in the userEmails list
            if(!users.Any(u => u.email == login.Email))
            {
                ModelState.AddModelError("Email", "Email not found.");
                return View();
            }
            
            // Find the user with the matching email
            User user = users.FirstOrDefault(u => u.email == login.Email);

            // Check if the password is correct
            if (user.password != login.Password)
            {
                ModelState.AddModelError("Password", "Palavra-passe incorreta!");
                return View();
            }

            string email = user.email;
            UserSession.Username = email;
            
            // Redirect to the home page
            return RedirectToAction("Index", "Home");
        }
        
        public IActionResult Home()
        {
            return RedirectToAction(controllerName: "Home", actionName: "Index");
        }
        
        public IActionResult Logout()
        {
                UserSession.Username = null;
                return RedirectToAction(controllerName: "Home", actionName: "Index");
        }

    }
}