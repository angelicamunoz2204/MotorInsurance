using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MotorInsurance.Models
{
    public class Vehicle
    {
        [BsonId]
        public string LicensePlate { get; set; }
        [BsonElement("model")]
        public int Model { get; set; }
        [BsonElement("inspection")]
        public bool Inspection { get; set; }
    }
}