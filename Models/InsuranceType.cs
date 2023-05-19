using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MotorInsurance.Models
{
    public class InsuranceType
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string InsuranceTypeID { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("maxCoverageAmount")]
        public int MaxCoverageAmount { get; set; }
        [BsonElement("insuranceCoverage")]
        public List<InsuranceCoverage> InsuranceCoverage { get; set; }
    }
}