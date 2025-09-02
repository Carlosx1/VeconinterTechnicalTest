using System.Text.RegularExpressions;
using VeconinterTechnicalTest.Application.Services.Interfaces;

namespace VeconinterTechnicalTest.Application.Services.Implementation;

// TODO: Validar si realmente es necesario este servicio
public class EmailValidationStrategy : IValidationStrategy<string>
{
    public bool IsValid(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;
                
        var pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        return Regex.IsMatch(email, pattern);

    }

    public string GetValidationMessage()
    {
        return "El formato del email no es válido";
    }
}