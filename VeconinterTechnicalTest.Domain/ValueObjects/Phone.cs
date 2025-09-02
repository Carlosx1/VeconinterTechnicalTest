using System.Text.RegularExpressions;

namespace VeconinterTechnicalTest.Domain.ValueObjects;

public class Phone
{
    public string Value { get; private set; }
        
    public Phone(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Phone cannot be empty");
                
        var cleanPhone = CleanPhone(value);
        if (!IsValidPhone(cleanPhone))
            throw new ArgumentException("Invalid phone format");
                
        Value = cleanPhone;
    }
        
    private static string CleanPhone(string phone)
    {
        return Regex.Replace(phone, @"[^\d+]", "");
    }
        
    private static bool IsValidPhone(string phone)
    {
        return Regex.IsMatch(phone, @"^\+?[\d]{8,15}$");
    }
        
    public static implicit operator string(Phone phone) => phone.Value;
    public static implicit operator Phone(string phone) => new(phone);
        
    public override string ToString() => Value;
}