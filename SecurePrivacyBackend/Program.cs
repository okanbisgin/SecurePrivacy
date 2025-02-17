using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SecurePrivacyBackend.Models;
using SecurePrivacyBackend.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") 
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials(); 
        });
});

builder.Services.Configure<MongoDBSettings>(
    builder.Configuration.GetSection("MongoDB"));

builder.Services.AddSingleton<MongoDBService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.MapGet("/users", async (MongoDBService mongoDBService) =>
{
    var users = await mongoDBService.GetUsersAsync();
    return Results.Ok(users);
})
.WithName("GetUsers")
.WithOpenApi();

app.MapPost("/users", async (MongoDBService mongoDBService, User user) =>
{
    await mongoDBService.CreateUserAsync(user);
    return Results.Created($"/users/{user.Id}", user);
})
.WithName("CreateUser")
.WithOpenApi();

app.Run();
