using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BozheHvatitDushitSharp.Models
{
    public class Log
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public string response { get; set; }
        public string request { get; set; }
        public Log()
        {
            TimeStamp = DateTime.Now;
        }
    }
}
