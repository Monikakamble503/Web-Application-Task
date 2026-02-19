using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyWebApp.Models
{
    public class QueueRecord
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string QueueName { get; set; } = null!;
        public string DocumentType { get; set; } = null!;

        [BsonElement("ActiveQueues")]
        public int ActiveQueues { get; set; }
        public int AssignedDocuments { get; set; }
    }
}