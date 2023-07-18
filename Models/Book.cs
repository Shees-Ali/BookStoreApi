using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookStoreApi.Models;
// Model For Book
public class Book
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    public string BookName { get; set; } = null!;
    public string Category { get; set; } = null!;
    public string Author { get; set; } = null!;
    public bool Completed { get; set; } = false;
    public string Status { get; set; } = null!;
    public string CompletedOn { get; set; } = null!;
}