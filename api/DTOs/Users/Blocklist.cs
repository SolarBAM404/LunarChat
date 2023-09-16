using MongoDB.Bson;
using MongoDbService.Models;

namespace LunarChat.DTOs.Users;

public class Blocklist : EntityBase
{
	public ObjectId UserId { get; set; }
	public ObjectId BlockedUserId { get; set; }
}