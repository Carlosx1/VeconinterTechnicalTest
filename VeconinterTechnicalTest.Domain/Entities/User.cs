using System.ComponentModel.DataAnnotations;

namespace VeconinterTechnicalTest.Domain.Entities;

public class User
{
    public int Id { get; set; }
        
    [Required]
    [StringLength(50)]
    public string Username { get; set; } = string.Empty;
        
    [Required]
    [StringLength(255)]
    public string PasswordHash { get; set; } = string.Empty;
        
    [Required]
    [EmailAddress]
    [StringLength(255)]
    public string Email { get; set; } = string.Empty;
        
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; } = true;
        
    public void Activate() => IsActive = true;
    public void Deactivate() => IsActive = false;

}