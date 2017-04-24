using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Loco.Models;
using MongoDB.Bson;
 
namespace Loco.Controllers
{
    [Route("api/file")]
    public class FileController : Controller
    {
        DataAccess objds;

        public FileController()
        {
            objds = new DataAccess(); 
        }
 
        [HttpGet]
        public IEnumerable<File> Get()
        {
            return objds.GetFiles();
        }
        [HttpGet("{id:length(24)}")]
        public IActionResult Get(string id)
        {
            var f = objds.GetFile(new ObjectId(id));
            if (f == null)
            {
                return NotFound();
            }
            return new ObjectResult(f);
        }
 
        [HttpPost]
        public IActionResult Post([FromBody]File f)
        {
            objds.CreateFile(f);
            return new OkObjectResult(f);
        }
        [HttpPut("{id:length(24)}")]
        public IActionResult Put(string id, [FromBody]File p)
        {
            var recId = new ObjectId(id);
            var file = objds.GetFile(recId);
            if (file == null)
            {
                return NotFound();
            }
            
            objds.UpdateFile(recId, p);
            return new OkResult();
        }
 
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var file = objds.GetFile(new ObjectId(id));
            if (file == null)
            {
                return NotFound();
            }
 
            objds.RemoveFile(file.Id);
            return new OkResult();
        }
    }
}