using Microsoft.AspNetCore.Identity;

namespace LunarChat.Models;

public class User
{
	public String Username { get; set; }
	public String Email { get; set; }
	public String HashPassword { get; set; }
}