using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models;

public record Colour
{
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonElement]
    public string Name { get; set; } = string.Empty;
}
