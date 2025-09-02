using System.Text.RegularExpressions;

namespace VeconinterTechnicalTest.Domain.ValueObjects;

public class Email
{
    public string Value { get; private set; }
        
    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Email cannot be empty");
                
        if (!IsValidEmail(value))
            throw new ArgumentException("Invalid email format");
                
        Value = value.ToLowerInvariant();
    }
        
    private static bool IsValidEmail(string email)
    {
        var pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        return Regex.IsMatch(email, pattern);
    }
        
    public static implicit operator string(Email email) => email.Value;
    public static implicit operator Email(string email) => new(email);
        
    public override string ToString() => Value;

}