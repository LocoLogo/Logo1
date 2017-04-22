using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
 
namespace Loco.Models
{
    public class Folder
    {
        [BsonElement("FolderID")]
        public ObjectId Id { get; set; }
        
        [BsonElement("FolderName")]
        public string FolderName { get; set; }
        
        [BsonElementAttribute("Repository")]
        public Project ProjectID { get; set; }
    }
}