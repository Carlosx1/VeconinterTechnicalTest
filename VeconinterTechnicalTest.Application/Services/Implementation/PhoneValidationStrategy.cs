using System.Text.RegularExpressions;
using VeconinterTechnicalTest.Application.Enums;
using VeconinterTechnicalTest.Application.Services.Interfaces;

namespace VeconinterTechnicalTest.Application.Services.Implementation;

// TODO: Validar si realmente es necesario este servicio
public class PhoneValidationStrategy : IValidationStrategy<string>
{
    public bool IsValid(string phone)
    {
        if (string.IsNullOrWhiteSpace(phone))
            return false;
                
        var cleanPhone = Regex.Replace(phone, @"[^\d+]", "");
        return Regex.IsMatch(cleanPhone, @"^\+?[\d]{8,15}$");

    }

    public string GetValidationMessage()
    {
        return "El formato del teléfono no es válido (8-15 dígitos)";
    }
    
    public ValidationStrategyEnum GetValidationStrategy()
    {
        return ValidationStrategyEnum.Phone;
    }
}