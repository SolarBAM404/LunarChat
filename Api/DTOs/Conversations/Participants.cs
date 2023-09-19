using MongoDB.Bson;

namespace Api.DTOs.Conversations;

public class Participants
{
	public ObjectId UserId { get; set; }
	public string? Alias { get; set; }
}