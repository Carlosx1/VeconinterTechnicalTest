using System.ComponentModel.DataAnnotations;

namespace VeconinterTechnicalTest.Application.DTOs;

public class UserDto
{
    public int Id { get; set; }
        
    [Required(ErrorMessage = "El usuario es requerido")]
    [StringLength(50, ErrorMessage = "El usuario no puede exceder 50 caracteres")]
    public string Username { get; set; } = string.Empty;
        
    [Required(ErrorMessage = "El email es requerido")]
    [EmailAddress(ErrorMessage = "Formato de email inválido")]
    public string Email { get; set; } = string.Empty;
        
    public bool IsActive { get; set; }

}

public class LoginDto
{
    [Required(ErrorMessage = "El usuario es requerido")]
    public string Username { get; set; } = string.Empty;
        
    [Required(ErrorMessage = "La contraseña es requerida")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
}
