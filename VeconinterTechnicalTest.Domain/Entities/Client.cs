using System.ComponentModel.DataAnnotations;

namespace VeconinterTechnicalTest.Domain.Entities;

public class Client
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
        
    [Required]
    [StringLength(100)]
    public string Company { get; set; } = string.Empty;
        
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        
    // Navegación a SubClientes
    public virtual ICollection<SubClient> SubClients { get; set; } = new List<SubClient>();
        
    public void UpdateInfo(string name, string email, string phone, string company)
    {
        Name = name;
        Email = email;
        Phone = phone;
        Company = company;
        UpdatedAt = DateTime.UtcNow;
    }

}