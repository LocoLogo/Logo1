using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Collections.Generic;
 
namespace Loco.Models
{
    public class DataAccess
    {
        MongoClient _client;
        MongoServer _server;
        MongoDatabase _db;
 
        public DataAccess()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _server = _client.GetServer();
            _db = _server.GetDatabase("LocoDB");      
        }
 
        public IEnumerable<User> GetUsers()
        {
            return _db.GetCollection<User>("Users").FindAll();
        }
 
 
        public User GetUser(ObjectId id)
        {
            var res = Query<User>.EQ(u=>u.Id,id);
            return _db.GetCollection<User>("Users").FindOne(res);
        }
 
        public User Create(User u)
        {
            _db.GetCollection<User>("Users").Save(u);
            return u;
        }
 
        public void Update(ObjectId id,User u)
        {
            u.Id = id;
            var res = Query<User>.EQ(up => up.Id,id);
            var operation = Update<User>.Replace(u);
            _db.GetCollection<User>("Users").Update(res,operation);
        }
        public void Remove(ObjectId id)
        {
            var res = Query<User>.EQ(e => e.Id, id);
            var operation = _db.GetCollection<User>("Users").Remove(res);
        }
    }
}