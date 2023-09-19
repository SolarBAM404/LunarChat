using Api.DTOs.Users;
using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.Bson;
using MongoDbGenericRepository.Attributes;

namespace Api.DTOs.Users;

[CollectionName("Users")]
public class ApplicationUser : MongoIdentityUser<ObjectId>
{
	private String _profileImageUrl = "profile_image_url";
	private String _status = "online";
	private List<Contacts> _contactsList = new List<Contacts>();


	public string ProfileImageUrl
	{
		get => _profileImageUrl;
		set => _profileImageUrl = value ?? throw new ArgumentNullException(nameof(value));
	}

	public string Status
	{
		get => _status;
		set => _status = value ?? throw new ArgumentNullException(nameof(value));
	}

	public List<Contacts> ContactsList
	{
		get => _contactsList;
		set => _contactsList = value ?? throw new ArgumentNullException(nameof(value));
	}
}