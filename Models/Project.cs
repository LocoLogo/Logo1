using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
 
namespace Loco.Models
{
    public class Project
    {
        [BsonElement("ProjectID")]
        public ObjectId Id { get; set; }
        
        [BsonElement("ProjectName")]
        public string ProjectName { get; set; }
        
        [BsonElement("ProjectDescription")]
        public string ProjectDescription { get; set; }
        
    }       
}