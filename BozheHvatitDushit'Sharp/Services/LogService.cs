using BozheHvatitDushitSharp.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BozheHvatitDushitSharp.Services
{
    public class LogService
    {
        IMongoCollection<Log> Logs;
        public LogService()
        {
            string connectionString = "mongodb+srv://Birug:awdszxfcv1@cluster0-fgudk.mongodb.net/test?retryWrites=true&w=majority";
            var connection = new MongoUrlBuilder(connectionString);
            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase(connection.DatabaseName);
            Logs = database.GetCollection<Log>("Logs");
            
        }

        public async Task Create(Log log)
        {
            await Logs.InsertOneAsync(log);
        }
    }
}
