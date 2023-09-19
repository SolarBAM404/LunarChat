using MongoDB.Bson;

namespace Api.DTOs.Users;

public class Contacts
{
	public ObjectId UserId { get; set; }
	public string? Alias { get; set; }
	public DateTime FriendsSince { get; set; }
}