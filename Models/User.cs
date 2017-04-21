using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Loco.Models
{
    public partial class User
    {
        [JsonIgnore]
        public ObjectId Id { get; set; }
        
        [BsonElement("UserName")]
        public string UserName { get; set; }
        
        [BsonElement("EmailAddress")]
        public string EmailAddress { get; set; }
        [BsonElement("Interests")]
        public string Interests { get; set; }
        [BsonElement("Role")]
        public string Role { get; set; }
        [BsonElement("About")]
        public string About { get; set; }
    }
}