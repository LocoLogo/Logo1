using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Loco.Models;
using MongoDB.Bson;
 
namespace Loco.Controllers
{
    [Route("api/user")]
    public class UserController : Controller
    {
        DataAccess objds;
 
        public UserController()
        {
            objds = new DataAccess(); 
        }
 
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return objds.GetUsers();
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
            objds.Create(u);
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
            
            objds.Update(recId, p);
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
 
            objds.Remove(user.Id);
            return new OkResult();
        }
    }
}