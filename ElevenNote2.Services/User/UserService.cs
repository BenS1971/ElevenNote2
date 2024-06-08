using ElevenNote2.Data;
using ElevenNote2.Data.Entities;
using ElevenNote2.Models.User;
using Microsoft.AspNetCore.Identity;

namespace ElevenNote2.Services.User;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<UserEntity> _userManager;
    private readonly SignInManager<UserEntity> _signInManager;
    public UserService(ApplicationDbContext context,
                        UserManager<UserEntity> userManager,
                        SignInManager<UserEntity> signInManager)
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
    }
                    
    public async Task<bool> RegisterUserAsync(UserRegister model)
    {
        UserEntity entity = new()
        {
            Email = model.Email,
            UserName = model.UserName,
            DateCreated = DateTime.Now
        };

        IdentityResult registerResult = await _userManager.CreateAsync(entity, model.Password);

        return registerResult.Succeeded;
    }

    private async Task<bool> CheckUserNameAvailabilityAsync(string userName)
    {
        UserEntity? existingUser = await _userManager.FindByNameAsync(userName);
        return existingUser is null;
    }

    private async Task<bool> CheckEmailAvailability(string email)
    {
        UserEntity? existingUser await _userManager.FindByEmailAsync(email);
        return existingUser is null;
    }

}