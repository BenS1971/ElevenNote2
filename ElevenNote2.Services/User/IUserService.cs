using ElevenNote.Models.User;

namespace ElevenNote2.Services.User;

public interface IUserService
{
    Task<bool> RegisterUserAsync(UserRegister model);
}