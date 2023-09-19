using MongoDbService.Models;

namespace Api.DTOs.Conversations;

public class Conversations : EntityBase
{
	private List<Participants> _participantsList;
	private List<Messages> _messages = new List<Messages>();

	public List<Participants> ParticipantsList
	{
		get => _participantsList;
		set => _participantsList = value ?? throw new ArgumentNullException(nameof(value));
	}

	public List<Messages> Messages
	{
		get => _messages;
	}
}