using System.ComponentModel.DataAnnotations;
using SistemaTarefas.Validations;

namespace SistemaTarefas.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email is required")]
        [CustomEmail(ErrorMessage = "Invalid format")]
        public string Email { get; set; }
        
        [MinLength(6)]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}