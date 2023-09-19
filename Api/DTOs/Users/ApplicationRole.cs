using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.Bson;
using MongoDbGenericRepository.Attributes;

namespace Api.DTOs.Users;

[CollectionName("Roles")]
public class ApplicationRole : MongoIdentityRole<ObjectId>
{

}