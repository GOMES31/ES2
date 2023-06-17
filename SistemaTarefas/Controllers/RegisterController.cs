using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using SistemaTarefas.Context;
using SistemaTarefas.Entities;
using SistemaTarefas.Models;
using System.Text.Json;

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

        try
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://localhost:5001");
                HttpResponseMessage response =  httpClient.GetAsync("api/WebAPI/userEmails").Result;
                
                Debug.WriteLine(response);

                if (!response.IsSuccessStatusCode)
                {
                    ViewBag.ErrorMessage = "An error occurred while processing the request.";
                    return View();
                }

                List<string> userEmails = await response.Content.ReadFromJsonAsync<List<string>>().ConfigureAwait(false);

                //Check if the register.Email already exists in the userEmails list
                if (userEmails.Contains(register.Email))
                {
                    ModelState.AddModelError("Email", "O email já está em uso.");
                    return View();
                }

                // Create a new object of User with the registration data
                User newUser = new User(register.Email, register.Password, register.Name);

                // Save the new user to the database
                _context.Users.Add(newUser);
                await _context.SaveChangesAsync().ConfigureAwait(false);

                UserSession.UserId = newUser.idUser;
                UserSession.Username = newUser.name;

                // Redirect to the home page
                return RedirectToAction("Index", "Home");
            }
        }
            
        catch (Exception ex)
        {
            ViewBag.ErrorMessage = "An error occurred while processing the request.";
            return View();
        }
    }

}  