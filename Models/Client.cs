using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MotorInsurance.Models
{
    public class Client
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ClientID{ get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("birthDate")]
        public DateTime BirthDate { get; set; }
        [BsonElement("city")]
        public string City { get; set; }
        [BsonElement("address")]
        public string Address { get; set; }
        [BsonElement("vehicle")]
        public Vehicle Vehicle { get; set; }
    }
}