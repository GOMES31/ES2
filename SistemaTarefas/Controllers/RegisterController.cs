using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using SistemaTarefas.Context;
using SistemaTarefas.Entities;
using SistemaTarefas.Models;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

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
    
    public async Task<IActionResult> Register([Bind("Email,Password,Name")] RegisterModel register)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        
                var users = await _context.Users.ToListAsync();
                
                
            // Check if the register.Email already exists in the userEmails list
                if (users.Any(u => u.email == register.Email))
                {
                    ModelState.AddModelError("Email", "The email is already in use.");
                    return View();
                }
                
                // Create a new object of User with the registration data
                User newUser = new User(register.Email, register.Password, register.Name);
                
                // Save the new user to the database
                _context.Users.Add(newUser);
                await _context.SaveChangesAsync().ConfigureAwait(false);

                string email = newUser.email;

                UserSession.Username = email;

                // Redirect to the home page
                return RedirectToAction("Index", "Home");
            }
} 
