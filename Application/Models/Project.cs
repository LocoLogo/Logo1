using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
 
namespace Loco.Models
{
    public partial class Project
    {
        
        [JsonIgnore]
        public ObjectId Id { get; set; }
        
        [BsonElement("ProjectName")]
        public string ProjectName { get; set; }
        
        [BsonElement("ProjectDepartment")]
        public string ProjectDepartment { get; set; }

        [BsonElement("ProjectDescription")]
        public string ProjectDescription { get; set; }

        [BsonElement("FileURL")]
        public string FileURL { get; set; }
        
    }       
}