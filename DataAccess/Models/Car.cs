using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataAccess.Models;

public record Car
{
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonElement]
    public string Model { get; set; } = string.Empty;

    [BsonElement]
    public Make? Make { get; set; }

    [BsonElement]
    public Colour? Colour { get; set; }

    [BsonElement]
    public int Horse { get; set; }
}