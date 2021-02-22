using System;
using System.Collections;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Form.Repository.Api.Entities
{
    public class form
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}