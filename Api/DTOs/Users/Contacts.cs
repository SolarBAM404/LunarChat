using MongoDB.Bson;

namespace LunarChat.DTOs.Users;

public class Contacts
{
	public ObjectId UserId { get; set; }
	public string? Alias { get; set; }
	public DateTime FriendsSince { get; set; }
}