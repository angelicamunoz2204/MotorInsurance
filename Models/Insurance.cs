using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MotorInsurance.Models
{
    public class Insurance
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string InsuranceID { get; set; }
        [BsonElement("startDate")]
        public DateTime StartDate { get; set; }
        [BsonElement("endDate")]
        public DateTime EndDate { get; set; }
        [BsonElement("insuranceType")]
        public InsuranceType InsuranceType { get; set; }
        [BsonElement("vehicle")]
        public Vehicle Vehicle { get; set; }
        [BsonElement("client")]
        public Client Client { get; set; }
    }
}