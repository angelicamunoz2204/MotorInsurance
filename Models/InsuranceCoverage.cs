using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Runtime.Serialization;

namespace MotorInsurance.Models
{
    public enum InsuranceCoverage
    {
        [EnumMember(Value = "Third party damage")]
        ThirdPartyDamage,
        [EnumMember(Value = "Car crashing")]
        CarCrashing,
        [EnumMember(Value = "Stealing")]
        Stealing,
        [EnumMember(Value = "Vandalism")]
        Vandalism,
        [EnumMember(Value = "Key replacement")]
        KeyReplacement,
        [EnumMember(Value = "Driver injuries")]
        DriverInjuries,
    }
}