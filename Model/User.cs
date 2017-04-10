
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
 
namespace Loco.Models
{
    public class User
    {
        public ObjectId Id { get; set; }
        [BsonElement("UserId")]
        public int UserId { get; set; }
        [BsonElement("UserName")]
        public string UserName { get; set; }
        [BsonElement("PersonalDescription")]
        public string PersonalDescription { get; set; }
        [BsonElement("EmailAddress")]
        public string EmailAddress { get; set; }
    }
}