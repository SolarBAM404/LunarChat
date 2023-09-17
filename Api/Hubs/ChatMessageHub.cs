using Microsoft.AspNetCore.SignalR;

namespace LunarChat.Hubs;

public class ChatMessageHub : Hub
{
	public async Task SendMessage(string toUser, string fromUser, string message)
	{
		await Clients.Users(toUser).SendAsync(message);
	}
}