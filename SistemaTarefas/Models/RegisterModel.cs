using System.ComponentModel.DataAnnotations;

namespace SistemaTarefas.Models;

public class RegisterModel
{
    [EmailAddress]
    public string Email { get; set; }
    [MinLength(6)]
    public string Password { get; set; }
    
    [StringLength(100)]
    public string Name { get; set; }
    
}