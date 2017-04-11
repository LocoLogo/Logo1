using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Loco.Models;
using MongoDB.Bson;
 
namespace Loco.Controllers
{
    [Route("api/folder")]
    public class FolderController : Controller
    {
        DataAccess objds;

        public FolderController()
        {
            objds = new DataAccess(); 
        }
 
        [HttpGet]
        public IEnumerable<Folder> Get()
        {
            return objds.GetFolders();
        }
        [HttpGet("{id:length(24)}")]
        public IActionResult Get(string id)
        {
            var f = objds.GetUser(new ObjectId(id));
            if (f == null)
            {
                return NotFound();
            }
            return new ObjectResult(f);
        }
 
        [HttpPost]
        public IActionResult Post([FromBody]Folder f)
        {
            objds.CreateFolder(f);
            return new OkObjectResult(f);
        }
        [HttpPut("{id:length(24)}")]
        public IActionResult Put(string id, [FromBody]Folder p)
        {
            var recId = new ObjectId(id);
            var user = objds.GetFolder(recId);
            if (user == null)
            {
                return NotFound();
            }
            
            objds.UpdateFolder(recId, p);
            return new OkResult();
        }
 
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var user = objds.GetFolder(new ObjectId(id));
            if (user == null)
            {
                return NotFound();
            }
 
            objds.RemoveFolder(Folder.Id);
            return new OkResult();
        }
    }
}