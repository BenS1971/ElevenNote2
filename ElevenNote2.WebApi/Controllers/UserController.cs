using ElevenNote.Models.User;
using ElevenNote2.Models.Responses;
using ElevenNote2.Services.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ElevenNote2.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpPost]
    public async Task<IActionResult> RegisterUserAsync([FromBody] UserRegister model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var registerResult = await _userService.RegisterUserAsync(model);
        if (registerResult)
        {
            TextResponse response = new("User was registered.");
            return Ok(response);
        }

        return BadRequest(new TextResponse("User coule not be registered."));
    }
}