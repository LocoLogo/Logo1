using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
 
namespace Loco.Models
{
    public class File
    {
        public ObjectId Id { get; set; }
        
        [BsonElement("FileName")]
        public string FileName { get; set; }
        
        [BsonElement("FileDescription")]
        public string FileDescription { get; set; }


        
    }       
}