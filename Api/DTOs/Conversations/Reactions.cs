using MongoDB.Bson;

namespace LunarChat.DTOs.Conversations;

public class Reactions
{
	public ObjectId UserId { get; set; }
	public String Emoji { get; set; }
	public DateTime Timestamp { get; set; }
}