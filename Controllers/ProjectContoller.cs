using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Loco.Models;
using MongoDB.Bson;
using System.IO;
using System.IO.Compression;
 
namespace Loco.Controllers
{
    [Route("api/project")]
    public class ProjectController : Controller
    {
        DataAccess objds;

        public ProjectController()
        {
            objds = new DataAccess(); 
        }
 
        [HttpGet]
        public IEnumerable<Project> Get()
        {
            return objds.GetProjects();
        }
        [HttpGet("{id:length(24)}")]
        public IActionResult Get(string id)
        {
            var f = objds.GetProject(new ObjectId(id));
            if (f == null)
            {
                return NotFound();
            }
            return new ObjectResult(f);
        }
 
        [HttpPost]
        public IActionResult Post([FromBody]Project f)
        {
            objds.CreateProject(f);
            return new OkObjectResult(f);
        }
        [HttpPut("{id:length(24)}")]
        public IActionResult Put(string id, [FromBody]Project p)
        {
            var recId = new ObjectId(id);
            var project = objds.GetProject(recId);
            if (project == null)
            {
                return NotFound();
            }
            
            objds.UpdateProject(recId, p);
            return new OkResult();
        }
 
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var project = objds.GetProject(new ObjectId(id));
            if (project == null)
            {
                return NotFound();
            }
 
            objds.RemoveProject(project.Id);
            return new OkResult();
        }

        /* Takes files and zips them* */
        public void CreateZip(){
            /* PROJECT FOLDER */
            string startPath = @"c:\example\start";
            /* PATH WE WANT ZIP TO BE */
            string zipPath = @"c:\example\result.zip";
            string extractPath = @"c:\example\extract";

            ZipFile.CreateFromDirectory(startPath, zipPath);
            ZipFile.ExtractToDirectory(zipPath, extractPath);
        }
        
    }
}