using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using VeconinterTechnicalTest.Application.DTOs;
using VeconinterTechnicalTest.Application.Services.Interfaces;
using VeconinterTechnicalTest.Domain.Entities;
using VeconinterTechnicalTest.Domain.Interfaces;

namespace VeconinterTechnicalTest.Application.Services.Implementation;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public AuthService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<UserDto?> AuthenticateAsync(LoginDto loginDto)
    {
        var user = await _unitOfWork.Users.GetByUsernameAsync(loginDto.Username);
            
        if (user == null || !user.IsActive)
            return null;
                
        if (!VerifyPassword(loginDto.Password, user.PasswordHash))
            return null;
                
        return _mapper.Map<UserDto>(user);

    }

    public async Task<UserDto> RegisterAsync(UserDto userDto, string password)
    {
        var existingUser = await _unitOfWork.Users.GetByUsernameAsync(userDto.Username);
        if (existingUser != null)
            throw new ArgumentException("El usuario ya existe");
            
        var user = new User
        {
            Username = userDto.Username,
            Email = userDto.Email,
            PasswordHash = HashPassword(password),
            IsActive = true
        };
            
        var createdUser = await _unitOfWork.Users.AddAsync(user);
        await _unitOfWork.SaveChangesAsync();
            
        return _mapper.Map<UserDto>(createdUser);

    }

    public string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password + "SALT_KEY"));
        return Convert.ToBase64String(hashedBytes);
    }

    public bool VerifyPassword(string password, string hash)
    {
        var hashedPassword = HashPassword(password);
        return hashedPassword == hash;
    }
}