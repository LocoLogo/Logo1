using Loco.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Loco.Controllers
{
    [Route("api/upload")]
    public class UploadController : Controller
    {
        DataAccess objds;
        IHostingEnvironment _appEnv;

        public UploadController(IHostingEnvironment appEnv)
        {
            _appEnv = appEnv;
            objds = new DataAccess();
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            if (Request.Form.Files.Count == 0)
            {
                return StatusCode(500, "Please provide a file");
            }
            
            try
            {
                var file = Request.Form.Files[0];
                if (file != null && file.Length > 0)
                {
                    var folderPath = Path.Combine(_appEnv.WebRootPath, "uploads");
                    var savePath = Path.Combine(folderPath, file.FileName);

                    if(!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    using (var fileStream = new FileStream(savePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    
                    Project savedProject = new Project();
                    savedProject.ProjectName = Request.Form["projectName"];
                    savedProject.ProjectDepartment = Request.Form["projectDepartment"];
                    savedProject.ProjectDescription = Request.Form["projectDescription"];
                    savedProject.FileURL = savePath;
                    objds.CreateProject(savedProject);

                    return Created(savePath, file);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
