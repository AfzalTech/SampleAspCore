using MongoDB.Driver;
using NetApp3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetApp3.Data
{
    public class DbContext
    {

        MongoClient _client;
        private readonly IMongoDatabase _db = null;

        public DbContext()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _db = _client.GetDatabase("testdb");
        }

        public IMongoCollection<CustomerM> Customers
        {
            get
            {
                return _db.GetCollection<CustomerM>("Customers");
            }
        }
    }
}
