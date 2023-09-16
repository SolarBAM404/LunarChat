using LunarChat.DTOs.Users;
using LunarChat.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LunarChat.Controllers.authentication;

[ApiController]
[ApiVersion("1.0")]
[Route("api/user-manager")]
public class UserApiManager : ControllerBase
{
	private UserManager<ApplicationUser> _userManager;

	public UserApiManager(UserManager<ApplicationUser> userManager)
	{
		_userManager = userManager;
	}

	[HttpPost]
	[Route("create/user")]
	public async Task<IActionResult> CreateUser(User user)
	{
		ApplicationUser applicationUser = new ApplicationUser()
		{
			UserName = user.Username,
			Email = user.Email,
			PasswordHash = user.HashPassword
		};
		IdentityResult result = await _userManager.CreateAsync(applicationUser);
		if (result.Succeeded)
		{
			return Ok("User created");
		}
		else
		{
			return BadRequest(result.Errors);
		}
	}
}