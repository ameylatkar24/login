using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Form.Buisness.Api.Entities
{
    public class credentials
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string id { get; set; }
        public string userId { get; set; }
        public string name { get; set; }
        public string password { get; set; }


    }
}