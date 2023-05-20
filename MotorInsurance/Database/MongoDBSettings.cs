using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotorInsurance.Database
{
    public class MongoDBSettings : IMongoDBSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}