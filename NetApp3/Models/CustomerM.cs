using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetApp3.Models
{
    [Table("Customers")]
    public class CustomerM
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string First { get; set; }

        public string Last { get; set; }

        
    }
}
