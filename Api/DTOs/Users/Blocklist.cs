using MongoDB.Bson;
using MongoDbService.Models;

namespace Api.DTOs.Users;

public class Blocklist : EntityBase
{
	public ObjectId UserId { get; set; }
	public ObjectId BlockedUserId { get; set; }
}