using System.ComponentModel.DataAnnotations;
using SistemaTarefas.Validations;

namespace SistemaTarefas.Models;

public class RegisterModel 
{
    [Required(ErrorMessage = "Email is required")]
    [CustomEmail(ErrorMessage = "Invalid format")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Password is required.")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
    public string Password { get; set; }
    
    [StringLength(100)]
    public string Name { get; set; }
    
}