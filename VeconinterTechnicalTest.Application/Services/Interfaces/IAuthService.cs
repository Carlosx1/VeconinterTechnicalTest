using VeconinterTechnicalTest.Application.DTOs;

namespace VeconinterTechnicalTest.Application.Services.Interfaces;

public interface IAuthService
{
    Task<UserDto?> AuthenticateAsync(LoginDto loginDto);
    Task<UserDto> RegisterAsync(UserDto userDto, string password);
    string HashPassword(string password);
    bool VerifyPassword(string password, string hash);
}