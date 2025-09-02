using System.ComponentModel.DataAnnotations;

namespace VeconinterTechnicalTest.Domain.Entities;

public class SubClient
{
    public int Id { get; set; }
        
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
        
    [Required]
    [EmailAddress]
    [StringLength(255)]
    public string Email { get; set; } = string.Empty;
        
    [Required]
    [Phone]
    [StringLength(20)]
    public string Phone { get; set; } = string.Empty;
        
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        
    // Clave foránea hacia Cliente
    public int ClientId { get; set; }
    public virtual Client Client { get; set; } = null!;
        
    public void UpdateInfo(string name, string email, string phone)
    {
        Name = name;
        Email = email;
        Phone = phone;
        UpdatedAt = DateTime.UtcNow;
    }
}