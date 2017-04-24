/*using Loco.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Shouldly;
using MongoDB.Driver;
using System.Linq;

namespace Logo.Test
{
    public class DBConnectionTests
    {
        MongoClient _client;
        MongoServer _server;
        MongoDatabase _db;

        public DBConnectionTests()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _server = _client.GetServer();
            _db = _server.GetDatabase("LocoDB");
        }

        [Fact]
        public void CreateUserTest()
        {
            User u = new User();
            u.UserName = "TestUserName";
            u.EmailAddress = "TestUserEmail";
            u.Interests = "TestUserInterests";
            u.Role = "TestUserEmail";
            u.About = "TestUserAbout";

            WriteConcernResult result = _db.GetCollection<User>("Users").Save(u);
            Assert.Equal(result.HasLastErrorMessage, false);
        }

        [Fact]
        public void GetLastUserTest()
        {
            User u = _db.GetCollection<User>("Users").FindAll().ToList<User>().LastOrDefault();
            u.ShouldNotBeNull();
        }
    }
}
*/