using System.Text;
using Api.DTOs.Users;
using Api.Hubs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

config.AddJsonFile(builder.Environment.IsDevelopment()
	? "appsettings.Development.json"
	: "appsettings.Production.json", false);

// Add services to the container.

var services = builder.Services;

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

String connectionString = config["ConnectionStrings:ConnStr"] ??
                          throw new NullReferenceException("Connection string could not be found");
String databaseName = config["ConnectionStrings:DatabaseName"] ??
                      throw new NullReferenceException("Database name could not be found");
services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
	{
		options.Password.RequireDigit = false;
		options.Password.RequireNonAlphanumeric = false;
		options.Password.RequireLowercase = false;
		options.Password.RequireUppercase = false;
		options.Password.RequiredLength = 96;
	})
	.AddMongoDbStores<ApplicationUser, ApplicationRole, ObjectId>(connectionString, databaseName);

services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(options =>
	{
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = true,
			ValidateAudience = true,
			ValidateLifetime = true,
			ValidateIssuerSigningKey = true,
			ValidIssuer = config["Jwt:Issuer"],
			ValidAudience = config["Jwt:Audience"],
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]))
		};
	});

services.AddSignalR();

services.AddCors(options =>
{
	options.AddDefaultPolicy(
		builder =>
		{
			builder.WithOrigins("http://localhost:3000")
				.AllowAnyHeader()
				.WithMethods("GET", "POST")
				.AllowCredentials();
		});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthorization();

app.MapControllers();
app.MapHub<ChatMessageHub>("/messages");

app.Run();