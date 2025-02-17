using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SecurePrivacyBackend.Models;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("name")]
    public string Name { get; set; } = null!;

    [BsonElement("email")]
    public string Email { get; set; } = null!;
}
