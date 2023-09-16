using MongoDB.Bson;
using MongoDbService.Models;

namespace LunarChat.DTOs.Conversations;

public class TypingStatus : EntityBase
{
	public ObjectId UserId { get; set; }
	public ObjectId ConversationId { get; set; }
	public bool IsTyping { get; set; } = false;
	public DateTime Timestamp { get; set; }
}