namespace Api.Controllers;

public class LoginUserModel
{
	public String Username { get; set; }
	public String HashPassword { get; set; }
	public bool RememberMe { get; set; } = false;
}