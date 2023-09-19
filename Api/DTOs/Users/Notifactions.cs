using MongoDB.Bson;
using MongoDbService.Models;

namespace Api.DTOs.Users;

public class Notifactions : EntityBase
{
	public ObjectId UserId { get; set; }
	public NotificationTypes Type { get; set; }
	public ObjectId? MessageId { get; set; }
	public bool IsRead { get; set; } = false;
	public DateTime Timestamp { get; set; }
}