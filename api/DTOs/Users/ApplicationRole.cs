using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.Bson;
using MongoDbGenericRepository.Attributes;

namespace LunarChat.DTOs.Users;

[CollectionName("Roles")]
public class ApplicationRole : MongoIdentityRole<ObjectId>
{

}