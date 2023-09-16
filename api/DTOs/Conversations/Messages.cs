using MongoDB.Bson;

namespace LunarChat.DTOs.Conversations;

public class Messages
{
	public ObjectId SenderId { get; set; }
	private String _text;
	public DateTime Timestamp { get; set; }
	public List<Reactions> Reactions { get; set; } = new List<Reactions>();
	public List<Attachments> Attachments { get; set; } = new List<Attachments>();
	public ObjectId? ParentMessageId { get; set; }

	public string Text
	{
		get => _text;
		set => _text = value ?? throw new ArgumentNullException(nameof(value));
	}
}