using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Collections.Generic;
using System.Linq;

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
 

        // Begin data access methods for user objects 
        public User GetUser()
        {
            return _db.GetCollection<User>("Users").FindAll().ToList<User>().LastOrDefault();
        }
        public User GetUser(ObjectId id)
        {
            var res = Query<User>.EQ(u=>u.Id,id);
            return _db.GetCollection<User>("Users").FindOne(res);
        }
        public User CreateUser(User u)
        {
            _db.GetCollection<User>("Users").Save(u);
            return u;
        }
        public void UpdateUser(ObjectId id,User u)
        {
            u.Id = id;
            var res = Query<User>.EQ(up => up.Id,id);
            var operation = Update<User>.Replace(u);
            _db.GetCollection<User>("Users").Update(res,operation);
        }
        public void RemoveUser(ObjectId id)
        {
            var res = Query<User>.EQ(e => e.Id, id);
            var operation = _db.GetCollection<User>("Users").Remove(res);
        }


        //Begin data access methods for project objects
        public IEnumerable<Project> GetProjects()
        {
            return _db.GetCollection<Project>("Projects").FindAll();
        }
 
        public Project GetProject(ObjectId id)
        {
            var res = Query<Project>.EQ(p=>p.Id,id);
            return _db.GetCollection<Project>("Projects").FindOne(res);
        }
 
        public Project CreateProject(Project p)
        {
            _db.GetCollection<Project>("Projects").Save(p);
            return p;
        }
 
        public void UpdateProject(ObjectId id,Project p)
        {
            p.Id = id;
            var res = Query<Project>.EQ(up => up.Id,id);
            var operation = Update<Project>.Replace(p);
            _db.GetCollection<Project>("Projects").Update(res,operation);
        }
        public void RemoveProject(ObjectId id)
        {
            var res = Query<Project>.EQ(e => e.Id, id);
            var operation = _db.GetCollection<Project>("Projects").Remove(res);
        }
    


        //begin data access methods for file objects
        public IEnumerable<File> GetFiles()
        {
            return _db.GetCollection<File>("Files").FindAll();
        }
 
        public File GetFile(ObjectId id)
        {
            var res = Query<File>.EQ(f=>f.Id,id);
            return _db.GetCollection<File>("Files").FindOne(res);
        }
 
        public File CreateFile(File f)
        {
            _db.GetCollection<File>("Files").Save(f);
            return f;
        }
 
        public void UpdateFile(ObjectId id,File f)
        {
            f.Id = id;
            var res = Query<File>.EQ(up => up.Id,id);
            var operation = Update<File>.Replace(f);
            _db.GetCollection<File>("Files").Update(res,operation);
        }
        public void RemoveFile(ObjectId id)
        {
            var res = Query<File>.EQ(e => e.Id, id);
            var operation = _db.GetCollection<File>("Files").Remove(res);
        }
    

        //Begin data access methods for folder objects
        public IEnumerable<Folder> GetFolders()
        {
            return _db.GetCollection<Folder>("Folders").FindAll();
        }
 
        public Folder GetFolder(ObjectId id)
        {
            var res = Query<Folder>.EQ(f=>f.Id,id);
            return _db.GetCollection<Folder>("Folders").FindOne(res);
        }
 
        public Folder CreateFolder(Folder f)
        {
            _db.GetCollection<Folder>("Folders").Save(f);
            return f;
        }
 
        public void UpdateFolder(ObjectId id,Folder f)
        {
            f.Id = id;
            var res = Query<Folder>.EQ(up => up.Id,id);
            var operation = Update<Folder>.Replace(f);
            _db.GetCollection<Folder>("Folders").Update(res,operation);
        }
        public void RemoveFolder(ObjectId id)
        {
            var res = Query<Folder>.EQ(e => e.Id, id);
            var operation = _db.GetCollection<Folder>("Folders").Remove(res);
        }
    }
}