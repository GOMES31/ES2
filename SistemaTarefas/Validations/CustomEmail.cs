using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SistemaTarefas.Validations;

public class CustomEmail : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        if (value == null)
            return true;

        string email = value.ToString();
        const string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        Regex regex = new Regex(pattern);

        return regex.IsMatch(email);
    }
}