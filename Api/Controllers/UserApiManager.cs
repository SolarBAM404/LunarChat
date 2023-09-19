using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Api.DTOs.Users;
using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver.Linq;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/user-manager")]
public class UserApiManager : ControllerBase
{
	private UserManager<ApplicationUser> _userManager;
	private readonly IConfiguration _configuration;

	public UserApiManager(UserManager<ApplicationUser> userManager,
		IConfiguration configuration)
	{
		_userManager = userManager;
		_configuration = configuration;
	}

	[HttpPost]
	[Route("register")]
	[AllowAnonymous]
	public async Task<IActionResult> CreateUser(UserModel userModel)
	{
		ApplicationUser? userExists = await _userManager.FindByNameAsync(userModel.Username);
		if (userExists != null)
			return StatusCode(StatusCodes.Status500InternalServerError,
				new ResponseModel { Status = "Error", Message = "User already exists!" });

		ApplicationUser applicationUser = new ApplicationUser()
		{
			UserName = userModel.Username,
			Email = userModel.Email
		};
		IdentityResult result = await _userManager.CreateAsync(applicationUser, userModel.HashPassword);
		return result.Succeeded ? Ok(new ResponseModel { Status = "Success", Message = "User created success!"})
			: BadRequest(result.Errors);
	}

	[HttpGet]
	[Route("login")]
	[AllowAnonymous]
	public async Task<IActionResult> LogInUser(LoginUserModel userModel)
	{
		ApplicationUser? applicationUser = await _userManager.FindByNameAsync(userModel.Username);

		if (applicationUser == null)
		{
			return Unauthorized("No user found with that username");
		}
		bool checkPasswordAsync = await _userManager.CheckPasswordAsync(applicationUser, userModel.HashPassword);
		if (!checkPasswordAsync)
		{
			return Unauthorized("Incorrect password");
		}

		IList<string> roles = await _userManager.GetRolesAsync(applicationUser);

		List<Claim> authClaims = new List<Claim>()
		{
			new Claim(ClaimTypes.Name, applicationUser.UserName),
			new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
		};

		foreach (string role in roles)
		{
			authClaims.Add(new Claim(ClaimTypes.Role, role));
		}

		JwtSecurityToken token = GetToken(authClaims, userModel.RememberMe);
		return Ok(new
		{
			token = new JwtSecurityTokenHandler().WriteToken(token),
			exiration = token.ValidTo
		});
	}

	private JwtSecurityToken GetToken(List<Claim> authClaims, bool rememberMe)
	{
		var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

		DateTime expireTime = rememberMe ? DateTime.Now.AddDays(60) : DateTime.Now.AddHours(3);

		var token = new JwtSecurityToken(
			issuer: _configuration["JWT:Issuer"],
			audience: _configuration["JWT:Audience"],
			expires: expireTime,
			claims: authClaims,
			signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
		);

		return token;
	}
}