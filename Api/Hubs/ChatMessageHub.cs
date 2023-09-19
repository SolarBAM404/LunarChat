using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Api.Hubs;

[Authorize]
public class ChatMessageHub : Hub
{
	public async Task SendMessage(string toUser, string fromUser, string message)
	{
		await Clients.Users(toUser).SendAsync(message);
	}
}