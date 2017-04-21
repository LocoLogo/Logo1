using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Loco.Models;
using MongoDB.Bson;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Loco.Controllers
{
    [Route("api/profile")]
    [ResponseCache(Location =ResponseCacheLocation.None, NoStore = true, Duration = -1)]
    public class ProfileController : Controller
    {
        DataAccess objds;

        public ProfileController()
        {
            objds = new DataAccess();
        }

        [HttpGet]
        public User Get()
        {
            User user = objds.GetUser();
            return user;
        }
        [HttpGet("{id:length(24)}")]
        public IActionResult Get(string id)
        {
            var user = objds.GetUser(new ObjectId(id));
            if (user == null)
            {
                return NotFound();
            }
            return new ObjectResult(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody]User u)
        {
            objds.CreateUser(u);
            return new OkObjectResult(u);
        }
        [HttpPut("{id:length(24)}")]
        public IActionResult Put(string id, [FromBody]User p)
        {
            var recId = new ObjectId(id);
            var user = objds.GetUser(recId);
            if (user == null)
            {
                return NotFound();
            }

            objds.UpdateUser(recId, p);
            return new OkResult();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var user = objds.GetUser(new ObjectId(id));
            if (user == null)
            {
                return NotFound();
            }

            objds.RemoveUser(user.Id);
            return new OkResult();
        }
    }
}
