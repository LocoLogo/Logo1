using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
 
namespace Loco.Models
{
    public partial class Folder
    {
        [JsonIgnore]
        public ObjectId Id { get; set; }
        
        [BsonElement("FolderName")]
        public string FolderName { get; set; }
        
        [BsonElementAttribute("Repository")]
        public Project ProjectID { get; set; }
    }
}