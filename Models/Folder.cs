using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
 
namespace Loco.Models
{
    public class Folder
    {
        public ObjectId Id { get; set; }
        [BsonElement("FolderID")]
        public int FolderName { get; set; }
        [BsonElement("FolderName")]
    }
}