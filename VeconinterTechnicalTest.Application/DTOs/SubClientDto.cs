using System.ComponentModel.DataAnnotations;

namespace VeconinterTechnicalTest.Application.DTOs;

public class SubClientDto
{
    public int Id { get; set; }
        
    [Required(ErrorMessage = "El nombre es requerido")]
    [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
    public string Name { get; set; } = string.Empty;
        
    [Required(ErrorMessage = "El email es requerido")]
    [EmailAddress(ErrorMessage = "Formato de email inválido")]
    public string Email { get; set; } = string.Empty;
        
    [Required(ErrorMessage = "El teléfono es requerido")]
    [Phone(ErrorMessage = "Formato de teléfono inválido")]
    public string Phone { get; set; } = string.Empty;
        
    public int ClientId { get; set; }
    public string ClientName { get; set; } = string.Empty;
        
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

}