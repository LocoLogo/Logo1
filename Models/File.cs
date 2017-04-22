using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
 
namespace Loco.Models
{
    public partial class File
    {

        [JsonIgnore]
        public ObjectId Id { get; set; }
        
        [BsonElement("FileName")]
        public string FileName { get; set; }
        
        [BsonElement("FileDescription")]
        public string FileDescription { get; set; }


        
    }       
}